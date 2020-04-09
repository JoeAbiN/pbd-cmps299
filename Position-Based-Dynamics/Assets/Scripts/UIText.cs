using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public GameObject target;

    void Update() {
        GetComponent<Text>().text = "Force: " + target.GetComponent<Ball>().force.ToString();
    }
}
