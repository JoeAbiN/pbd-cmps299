using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class Ball : MonoBehaviour {
    public float force = 25f;
    public float succForce = 2f;
    private Rigidbody rigidbody;
    public GameObject target;

    float dt;
    public Vector3 d;
    private Vector3 targetPoint;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        // Time.fixedDeltaTime /= 5;
        dt = Time.fixedDeltaTime;
        Debug.Log(dt);
    }

    void Update() {
        targetPoint = GetComponent<NearestPointTest>().targetPoint;
        d = targetPoint - transform.position;

        // int layerMask = 1 << 8;

        // layerMask = ~layerMask;

        // RaycastHit hit;

        // if (Physics.Raycast(transform.position, 
        //                     d, 
        //                     out hit, Mathf.Infinity)) {

        //     Debug.DrawRay(transform.position, 
        //                   d * hit.distance, 
        //                   Color.yellow);

        //     // Debug.DrawRay(transform.position, transform.position + rigidbody.velocity * 100, Color.red);
        // }
        // else
        // {
        //     Debug.DrawRay(transform.position, d * 1000, Color.white);
        //     Debug.Log("Did not Hit");
        // }

        if (d.magnitude < transform.localScale.x) {
            Debug.DrawRay(transform.position, d * 1000, Color.yellow);
            rigidbody.velocity = rigidbody.velocity * d.magnitude;
        
        } else {
            Debug.DrawRay(transform.position, d * 1000, Color.white);
        }

        // Debug.DrawRay(transform.position, rigidbody.velocity * 1000, Color.red);
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // rigidbody.AddForce((Vector3.forward + Vector3.up) * force);
            // Vector3 tempVelocity = rigidbody.velocity;
            // rigidbody.velocity = new Vector3(tempVelocity.x, tempVelocity.y * force/2, tempVelocity.z * force);
            
            // rigidbody.AddForce(Vector3.forward * force + Vector3.up * force/2);
            rigidbody.velocity = new Vector3(0, force*dt / 2, force*dt);

            // Debug.Log(GetComponent<FlexSolidActor>().asset);
        }

        // rigidbody.velocity = rigidbody.velocity - rigidbody.velocity/d
        // if (d.magnitude < 1) { rigidbody.velocity = rigidbody.velocity / d.magnitude ; }

        // if (d.magnitude < 1) { rigidbody.velocity = rigidbody.velocity - d/d.magnitude; }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Net")) {
            Debug.Log("hit net");
            rigidbody.velocity = Vector3.zero;
        }
    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position, 0.1f);
    //     Gizmos.DrawWireCube(transform.position, transform.GetComponent<Renderer>().bounds.size);
    //     Gizmos.DrawWireCube(target.transform.position, target.transform.GetComponent<Renderer>().bounds.size);
    // }
}
