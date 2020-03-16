using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private float force = 500f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // rigidbody.AddForce((Vector3.forward + Vector3.up) * force);
            // Vector3 tempVelocity = rigidbody.velocity;
            // rigidbody.velocity = new Vector3(tempVelocity.x, tempVelocity.y * force/2, tempVelocity.z * force);
            rigidbody.AddForce(Vector3.forward * force + Vector3.up * force/2);
        }
    }
}
