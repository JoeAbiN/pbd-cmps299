using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllisionDetection : MonoBehaviour {
    public GameObject ball;
    public GameObject net;

    private Bounds ballBounds;
    private Bounds netBounds;

    private Vector3 origiBall;
    private Vector3 origiNet;

    void Start() {
        origiBall = ball.transform.position;
        origiNet = net.transform.position;

        ballBounds = ball.GetComponent<Renderer>().bounds;
        netBounds = net.GetComponent<Renderer>().bounds;
    }

    void Update() {
        if (ballBounds.Intersects(netBounds)) {
            Debug.Log("INTERSECT!!!!!!");
        }

        Debug.Log(ballBounds.Intersects(netBounds));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            net.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ball.transform.position = origiBall;
            net.transform.position = origiNet;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ball.transform.position, ballBounds.size);
        Gizmos.DrawWireCube(net.transform.position, netBounds.size);
    }
}
