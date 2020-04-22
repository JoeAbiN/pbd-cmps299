using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetCam0;
    public GameObject targetCam1;
    public GameObject targetCam2;
    public GameObject targetCam3;
    public GameObject targetCam4;
    public GameObject targetCam5;
	
	private Camera cam0;
    private Camera cam1;
    private Camera cam2;
    private Camera cam3;
    private Camera cam4;
    private Camera cam5;

	void Start()
	{
		cam0 = targetCam0.GetComponent<Camera>();
		cam1 = targetCam1.GetComponent<Camera>();
		cam2 = targetCam2.GetComponent<Camera>();
		cam3 = targetCam3.GetComponent<Camera>();
		cam4 = targetCam4.GetComponent<Camera>();
		cam5 = targetCam5.GetComponent<Camera>();
	}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            cam0.depth = 1;
            cam1.depth = 0;
            cam2.depth = 0;
            cam3.depth = 0;
            cam4.depth = 0;
            cam5.depth = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            cam0.depth = 0;
            cam1.depth = 1;
            cam2.depth = 0;
            cam3.depth = 0;
            cam4.depth = 0;
            cam5.depth = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            cam0.depth = 0;
            cam1.depth = 0;
            cam2.depth = 1;
            cam3.depth = 0;
            cam4.depth = 0;
            cam5.depth = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            cam0.depth = 0;
            cam1.depth = 0;
            cam2.depth = 0;
            cam3.depth = 1;
            cam4.depth = 0;
            cam5.depth = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            cam0.depth = 0;
            cam1.depth = 0;
            cam2.depth = 0;
            cam3.depth = 0;
            cam4.depth = 1;
            cam5.depth = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            cam0.depth = 0;
            cam1.depth = 0;
            cam2.depth = 0;
            cam3.depth = 0;
            cam4.depth = 0;
            cam5.depth = 1;
        }
    }
}
