using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllisionDetection : MonoBehaviour {
    public GameObject ball;

    private Bounds ballBounds;

    private Vector3 origiBall;

    void Start() {
        origiBall = ball.transform.position;
        
        ballBounds = ball.GetComponent<Renderer>().bounds;
    }

    void Update() {
        // if (ballBounds.Intersects(netBounds)) {
        //     Debug.Log("INTERSECT!!!!!!");
        // }

        // Debug.Log(ballBounds.Intersects(netBounds));

        if (Input.GetKeyDown(KeyCode.Z)) {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            ball.transform.position = origiBall;
        }
    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireCube(ball.transform.position, ballBounds.size);
    //     Gizmos.DrawWireCube(net.transform.position, netBounds.size);
    // }
}
