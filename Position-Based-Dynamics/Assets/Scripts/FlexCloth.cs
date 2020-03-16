using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FlexCloth : MonoBehaviour {
    public FlexClothActor actor;
    private FlexClothAsset asset;
    private Mesh refMesh;

    private MeshFilter meshFilter;
    private Mesh myMesh;
    
    void Start() {
        asset = actor.asset;
        refMesh = asset.referenceMesh;
        
        meshFilter = GetComponent<MeshFilter>();
        myMesh = meshFilter.mesh;

        Render();
    }

    void Update() {
        // for (int i = 0; i < myMesh.vertices.Length; i++) {
        //     Vector3 tempPos = myMesh.vertices[i].position;
        //     myMesh.vertices[i].position = new Vector3(tempPos.x, tempPos.y, (float)Math.Sin(Time.time - tempPos.x));
        // }
        
        Render();
    }

    void Render() {
        myMesh.Clear();
        myMesh.vertices = refMesh.vertices;
        for (int i = 0; i < myMesh.vertices.Length; i++) {
            Vector3 tempPos = myMesh.vertices[i];
            myMesh.vertices[i] = new Vector3(tempPos.x, tempPos.y, (float)Math.Sin(Time.time - tempPos.x));
        }
        myMesh.triangles = refMesh.triangles;
        myMesh.RecalculateNormals();
    }
}
