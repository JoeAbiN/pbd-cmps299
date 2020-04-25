using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Vector3 origiPos;
    private Rigidbody rigidbody;
    public Transform camera;
    
    public float force = 0;
    public float maxForce = 1000;
    private Vector3 F;
    float y;
    float dt;
    
    public float n = 5f;

    public GameObject shotBar;
    private RectTransform barTransform;

    private LineRenderer lineRenderer;

    void Start() {
        origiPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        
        dt = Time.fixedDeltaTime;
        y = 0.5f;
        force = 0;
        
        barTransform = shotBar.GetComponent<RectTransform>();
        barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);

        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        F = new Vector3(camera.forward.x, y, camera.forward.z);

        lineRenderer.SetPosition(0, origiPos);
        lineRenderer.SetPosition(1, origiPos + 6*F);

        if (Input.GetKey(KeyCode.W)) {
            y += 0.1f * dt;
        
        } else if (Input.GetKey(KeyCode.S)) {
            y -= 0.1f * dt;
        }

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
