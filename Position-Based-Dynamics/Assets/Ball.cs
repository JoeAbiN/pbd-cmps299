using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Vector3 origiPos;
    private Rigidbody rigidbody;
    public Transform camera;
    public GameObject camHandler;
    private Camera camComp;
    
    public float force = 0;
    public float maxForce = 1200;
    private Vector3 F;
    float y;
    float dt;
    bool isShot;

    public GameObject shotBar;
    private RectTransform barTransform;

    private LineRenderer lineRenderer;

    void Start() {
        origiPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        camComp = camHandler.GetComponent<CamSwitch>().targetCam0.GetComponent<Camera>();
        
        dt = Time.fixedDeltaTime;
        y = 0.5f;
        force = 0;
        isShot = false;
        
        barTransform = shotBar.GetComponent<RectTransform>();
        barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);

        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        //Set shot vector
        F = new Vector3(camera.forward.x, y, camera.forward.z);

        // Render Line
        if (camComp.depth == 0 || isShot) {
            lineRenderer.SetPosition(1, origiPos);
        
        } else {
            lineRenderer.SetPosition(1, origiPos + 8*F);
        }
        lineRenderer.SetPosition(0, origiPos);
        
        //Set ball position
        if (Input.GetKey(KeyCode.I)) {
            transform.Translate(Vector3.forward * dt * 2, Space.World);
            camera.transform.Translate(Vector3.forward * dt * 2, Space.World);
            camComp.gameObject.transform.Translate(Vector3.forward * dt * 2, Space.World);
            origiPos = transform.position;
        
        } else if (Input.GetKey(KeyCode.K)) {
            transform.Translate(-Vector3.forward * dt * 2, Space.World);
            camera.transform.Translate(-Vector3.forward * dt * 2, Space.World);
            camComp.gameObject.transform.Translate(-Vector3.forward * dt * 2, Space.World);
            origiPos = transform.position;

        } else if (Input.GetKey(KeyCode.J)) {
            transform.Translate(-Vector3.right * dt * 2, Space.World);
            camera.transform.Translate(-Vector3.right * dt * 2, Space.World);
            camComp.gameObject.transform.Translate(-Vector3.right * dt * 2, Space.World);
            origiPos = transform.position;

        } else if (Input.GetKey(KeyCode.L)) {
            transform.Translate(Vector3.right * dt * 2, Space.World);
            camera.transform.Translate(Vector3.right * dt * 2, Space.World);
            camComp.gameObject.transform.Translate(Vector3.right * dt * 2, Space.World);
            origiPos = transform.position;
        }

        //Aim up/down
        if (Input.GetKey(KeyCode.W)) {
            y += 0.2f * dt;
        
        } else if (Input.GetKey(KeyCode.S)) {
            y -= 0.2f * dt;
        }

        //Charge shot
        if (Input.GetKey(KeyCode.Space)) {
            if (force < maxForce) {
                force += 40;
            }
        }

        //Release shot
        if (Input.GetKeyUp(KeyCode.Space)) {
            isShot = true;
            barTransform.sizeDelta = new Vector2(0, barTransform.sizeDelta.y);
            rigidbody.velocity = F * force * dt;
            force = 0;
        }

        //Reset position
        if (Input.GetKeyDown(KeyCode.Z)) {
            isShot = false;
            force = 0;
            rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity  = Vector3.zero;
            transform.position = origiPos;
        }

        //Fill up power bar
        barTransform.sizeDelta = new Vector2(force / (maxForce/200), barTransform.sizeDelta.y);
    }
}
