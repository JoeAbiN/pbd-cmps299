using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllisionDetection : MonoBehaviour {
    public GameObject ball;
    public GameObject net;

    private Bounds ballBounds;
    private Bounds netBounds;

    void Start() {
        ballBounds = ball.GetComponent<Renderer>().bounds;
        netBounds = net.GetComponent<Renderer>().bounds;
    }

    void Update() {
        if (ballBounds.Intersects(netBounds)) {
            Debug.Log("INTERSECT!!!!!!");
        }

        Debug.Log(ballBounds.Intersects(netBounds));
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ball.transform.position, ballBounds.size);
        Gizmos.DrawWireCube(net.transform.position, netBounds.size);
    }
}
