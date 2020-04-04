using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FlexCloth : MonoBehaviour {
    public GameObject target;
    private Mesh myMesh;
    private Mesh targetMesh;

    // public FlexClothActor actor;
    // private FlexClothAsset asset;
    // private Mesh refMesh;

    // private MeshFilter meshFilter;
    // private Mesh myMesh;
    
    void Start() {
        myMesh = GetComponent<MeshFilter>().mesh;
        targetMesh = target.GetComponent<MeshFilter>().mesh;
        
    //     asset = actor.asset;
    //     refMesh = asset.referenceMesh;
        
    //     meshFilter = GetComponent<MeshFilter>();
    //     myMesh = meshFilter.mesh;

    //     Render();
    }

    void Update() {
        Debug.ClearDeveloperConsole();

        float minDistance = (myMesh.vertices[0] - targetMesh.vertices[0]).magnitude;
        foreach (Vector3 v in myMesh.vertices) {
            foreach (Vector3 w in targetMesh.vertices) {
                if ((v - w).magnitude < minDistance) {
                    minDistance = (v - w).magnitude;
                }
            }
        }

        Debug.Log(minDistance);
        // for (int i = 0; i < myMesh.vertices.Length; i++) {
        //     Vector3 tempPos = myMesh.vertices[i].position;
        //     myMesh.vertices[i].position = new Vector3(tempPos.x, tempPos.y, (float)Math.Sin(Time.time - tempPos.x));
        // }
        
        // Render();
    }

    // void Render() {
    //     myMesh.Clear();
    //     myMesh.vertices = refMesh.vertices;
    //     for (int i = 0; i < myMesh.vertices.Length; i++) {
    //         Vector3 tempPos = myMesh.vertices[i];
    //         myMesh.vertices[i] = new Vector3(tempPos.x, tempPos.y, (float)Math.Sin(Time.time - tempPos.x));
    //     }
    //     myMesh.triangles = refMesh.triangles;
    //     myMesh.RecalculateNormals();
    // }
}
