using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle {
    //Corners
    public Vertex v1;
    public Vertex v2;
    public Vertex v3;

    //If we are using the half edge mesh structure, we just need one half edge
    public HalfEdge halfEdge;

    public Triangle(Vertex v1, Vertex v2, Vertex v3) {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    public Triangle(Vector3 v1, Vector3 v2, Vector3 v3) {
        this.v1 = new Vertex(v1);
        this.v2 = new Vertex(v2);
        this.v3 = new Vertex(v3);
    }

    public Triangle(HalfEdge halfEdge) {
        this.halfEdge = halfEdge;
    }

    //Change orientation of triangle from cw -> ccw or ccw -> cw
    public void ChangeOrientation() {
        Vertex temp = this.v1;
        this.v1 = this.v2;
        this.v2 = temp;
    }

    //Convert a Triangle array to an int array in order to render in Unity
    public static int[] toIndices(Triangle[] triangles, Vertex[] vertices) {
        List<int> temp = new List<int>();
        int[] result = new int[triangles.Length * 3];

        foreach (Triangle triangle in triangles) {
            temp.Add(Array.IndexOf(vertices, triangle.v1));
            temp.Add(Array.IndexOf(vertices, triangle.v2));
            temp.Add(Array.IndexOf(vertices, triangle.v3));
        }

        for (int i = 0; i < result.Length; i++) {
            result[i] = temp[i];
        }

        return result;
    }

    //Is a triangle in 2d space oriented clockwise or counter-clockwise
    //https://math.stackexchange.com/questions/1324179/how-to-tell-if-3-connected-points-are-connected-clockwise-or-counter-clockwise
    //https://en.wikipedia.org/wiki/Curve_orientation
    public static bool isClockwise(Vector2 p1, Vector2 p2, Vector2 p3) {
        bool result = true;
        float determinant = p1.x * p2.y + p3.x * p1.y + p2.x * p3.y - p1.x * p3.y - p3.x * p2.y - p2.x * p1.y;

        if (determinant > 0f) {
            result = false;
        }

        return result;
    }

    //Orient triangles so they have the correct orientation
    public static void OrientClockwise(List<Triangle> triangles) {
        for (int i = 0; i < triangles.Count; i++) {
            Triangle tri = triangles[i];

            Vector2 v1 = new Vector2(tri.v1.position.x, tri.v1.position.z);
            Vector2 v2 = new Vector2(tri.v2.position.x, tri.v2.position.z);
            Vector2 v3 = new Vector2(tri.v3.position.x, tri.v3.position.z);

            if (!Triangle.isClockwise(v1, v2, v3)) {
                tri.ChangeOrientation();
            }
        }
    }

    //From triangle where each triangle has one vertex to half edge
    public static List<HalfEdge> toHalfEdges(List<Triangle> triangles) {
        //Make sure the triangles have the same orientation
        Triangle.OrientClockwise(triangles);

        //First create a list with all possible half-edges
        List<HalfEdge> halfEdges = new List<HalfEdge>(triangles.Count * 3);

        for (int i = 0; i < triangles.Count; i++) {
            Triangle t = triangles[i];
        
            HalfEdge he1 = new HalfEdge(t.v1);
            HalfEdge he2 = new HalfEdge(t.v2);
            HalfEdge he3 = new HalfEdge(t.v3);

            he1.nextEdge = he2;
            he2.nextEdge = he3;
            he3.nextEdge = he1;

            he1.prevEdge = he3;
            he2.prevEdge = he1;
            he3.prevEdge = he2;

            //The vertex needs to know of an edge going from it
            he1.v.halfEdge = he2;
            he2.v.halfEdge = he3;
            he3.v.halfEdge = he1;

            //The face the half-edge is connected to
            t.halfEdge = he1;

            he1.t = t;
            he2.t = t;
            he3.t = t;

            //Add the half-edges to the list
            halfEdges.Add(he1);
            halfEdges.Add(he2);
            halfEdges.Add(he3);
        }

        //Find the half-edges going in the opposite direction
        for (int i = 0; i < halfEdges.Count; i++) {
            HalfEdge he = halfEdges[i];

            Vertex goingToVertex = he.v;
            Vertex goingFromVertex = he.prevEdge.v;

            for (int j = 0; j < halfEdges.Count; j++) {
                //Dont compare with itself
                if (i == j) {
                    continue;
                }

                HalfEdge heOpposite = halfEdges[j];

                //Is this edge going between the vertices in the opposite direction
                if (goingFromVertex.position == heOpposite.v.position && goingToVertex.position == heOpposite.prevEdge.v.position) {
                    he.oppositeEdge = heOpposite;
                    break;
                }
            }
        }

        return halfEdges;
    }
}