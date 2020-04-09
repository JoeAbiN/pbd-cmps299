using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class Ball : MonoBehaviour {
    private Vector3 origiPos;
    public float force = 0;
    public float maxForce = 1000;
    private Rigidbody rigidbody;
    public Transform camera;
    private Vector3 F;
    float dt;
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
        if (Input.GetKey(KeyCode.Space)) {
            if (force < maxForce) {
                force += 50;
            }

            barTransform.sizeDelta = new Vector2(force, barTransform.sizeDelta.y);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            force = 0;
            rigidbody.velocity = Vector3.zero;
            transform.position = origiPos;
        }
    }

    void FixedUpdate() {
        F = new Vector3(camera.forward.x, 0.5f, camera.forward.z);
        Debug.DrawRay(transform.position, F * 10, Color.red);
        if (Input.GetKeyUp(KeyCode.Space)) {
            barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);
            // rigidbody.velocity = new Vector3(0, force*dt / 2, force*dt);
            // F = camera.worldToLocalMatrix.MultiplyVector(camera.forward);
            Debug.Log(F);
            rigidbody.velocity = F * force * dt;
            // rigidbody.velocity = new Vector3(0, F.y * force/2 * dt, F.z * force * dt);
        }

    }
}
