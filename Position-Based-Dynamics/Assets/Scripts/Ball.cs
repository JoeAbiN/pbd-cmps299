using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class Ball : MonoBehaviour {
    private Vector3 origiPos;
    private Rigidbody rigidbody;
    public Transform camera;
    
    public float force = 0;
    public float maxForce = 1000;
    private Vector3 F;
    float dt;
    
    public float n = 5f;

    public GameObject shotBar;
    private RectTransform barTransform;

    void Start() {
        origiPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        dt = Time.fixedDeltaTime;
        force = 0;
        barTransform = shotBar.GetComponent<RectTransform>();
        barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);
    }

    void Update() {
        F = new Vector3(camera.forward.x, 0.5f, camera.forward.z);

        if (Input.GetKey(KeyCode.Space)) {
            if (force < maxForce) {
                force += 10;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);
            rigidbody.velocity = F * force * dt;
            force = 0;
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            force = 0;
            rigidbody.velocity = Vector3.zero;
            transform.position = origiPos;
        }

        barTransform.sizeDelta = new Vector2(force / n, barTransform.sizeDelta.y);
    }
}
