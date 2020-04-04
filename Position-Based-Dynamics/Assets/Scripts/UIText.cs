using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public GameObject target;

    void Update() {
        GetComponent<Text>().text = "d: " + target.GetComponent<Ball>().d.ToString() + "\n||d||: " +
                                    target.GetComponent<Ball>().d.magnitude + "\nv: " + 
                                    target.GetComponent<Rigidbody>().velocity.ToString() + "\n||v||: " +
                                    target.GetComponent<Rigidbody>().velocity.magnitude;
    }
}
