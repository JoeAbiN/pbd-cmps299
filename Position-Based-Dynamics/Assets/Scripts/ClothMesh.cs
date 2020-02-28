using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ClothMesh : MonoBehaviour {
    private Vertex[] vertices;
    private int[] indices;
    private List<Triangle> triangles = new List<Triangle>();
    private Mesh mesh;
    public int xSize = 10;
    public int ySize = 10;
    public GameObject sphere;
    public GameObject cylinder;
    List<GameObject> sphereArray = new List<GameObject>();
    List<GameObject> cylinderArray = new List<GameObject>();
    List<HalfEdge> edges = new List<HalfEdge>();

    void Start() {
        //The MeshFilter component's mesh field stores information about vertices and triangles and uses them to render the mesh
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.name = "Cloth Mesh";

        vertices = new Vertex[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++) {
            for (int x = 0; x <= xSize; x++, i++) {
                vertices[i] = new Vertex(new Vector3(x, y));
            }
        }
        for (int i =0; i < vertices.Length; i++) {

        }

        for (int i = 0; i < vertices.Length; i++) {
            sphereArray.Add(Instantiate(sphere, vertices[i].position, Quaternion.identity));
        }
        indices = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
            for (int x = 0; x < xSize; x++, ti += 6, vi++) {
                indices[ti] = vi;
                indices[ti + 3] = indices[ti + 2] = vi + 1;
                indices[ti + 4] = indices[ti + 1] = vi + xSize + 1;
                indices[ti + 5] = vi + xSize + 2;
            }
        }

        for (int i = 0; i < indices.Length; i += 3) {
            triangles.Add(new Triangle(
                vertices[indices[i]], vertices[indices[i + 1]], vertices[indices[i + 2]]
            )); 
        }
        
        Render();
    }

    void Update() {
        //Simple movement: every vertex's z component is set to be z = sin(time - x) with x being its x component
        for (int i = 0; i < vertices.Length; i++) {
            Vector3 tempPos = vertices[i].position;
            vertices[i].position = new Vector3(tempPos.x, tempPos.y, (float)Math.Sin(Time.time - tempPos.x));
        }

        Render();
    }

    //After the corresponding vertices and triangles are assigned to the mesh, RecalculateNormals() is called for lighting calculations
    void Render() {
        mesh.Clear();
        mesh.vertices = Vertex.toVector3(vertices);
        //Moving the spheres with every render
        for (int i = 0; i < sphereArray.Count; i++) {
            sphereArray[i].transform.position = vertices[i].position;
            sphereArray[i].transform.position = vertices[i].position;

        }
        mesh.triangles = Triangle.toIndices(triangles.ToArray(), vertices);
        mesh.RecalculateNormals();
    }

    //Black dots are drawn at each vertex position for debugging purposes
    void OnDrawGizmos() {
        
        Vector3[] drawnVertices = Vertex.toVector3(vertices);
        Gizmos.color = Color.black;
        
        for (int i = 0; i < drawnVertices.Length; i++) {
            Gizmos.DrawSphere(drawnVertices[i], 0.1f);
		}
        
    }
}