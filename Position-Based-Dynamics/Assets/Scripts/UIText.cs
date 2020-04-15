using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public GameObject target;
    private Cloth cloth;

    private Text text;

    public float changeRate = 0.01f;

    void Start() {
        text = GetComponent<Text>();
        cloth = target.GetComponent<Cloth>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            cloth.bendingStiffness += changeRate;
        
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            cloth.bendingStiffness -= changeRate;
        
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            cloth.stretchingStiffness -= changeRate;
        
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            cloth.stretchingStiffness += changeRate;
        }

        text.text = "Bending Stiffness:\n" + cloth.bendingStiffness.ToString()
        + "\nStretching Stiffness:\n" + cloth.stretchingStiffness.ToString();
    }
}
