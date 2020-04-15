using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    public Transform target;
    public float rotSpeed = 30;
    
    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            transform.RotateAround(target.transform.position, Vector3.up, rotSpeed * Time.deltaTime);
        
        } else if (Input.GetKey(KeyCode.W)) {
            transform.RotateAround(target.transform.position, Vector3.up, -rotSpeed * Time.deltaTime);
        }
    }
}
