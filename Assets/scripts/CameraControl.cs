using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject go_camera = null;
    public float rotation_speed = 360;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = -Input.GetAxis("Mouse Y") * rotation_speed * Time.deltaTime;
        float nextX = go_camera.transform.localEulerAngles.x + dx;

        //Debug.Log(nextX);

        //go_camera.transform.Rotate(Input.GetAxis("Mouse Y") * rotation_speed * Time.deltaTime, 0, 0);

        //Debug.Log(go_camera.transform.eulerAngles.x);
        //Debug.Log(go_camera.transform.rotation.eulerAngles.x); 
        //Debug.Log(go_camera.transform.localEulerAngles);
        //Debug.Log(go_camera.transform.localRotation);
        
        if (nextX > 90 && nextX <= 180)
        {
            go_camera.transform.localEulerAngles = new Vector3(90, go_camera.transform.localEulerAngles.y, go_camera.transform.localEulerAngles.z);
        }
        else if (nextX >= 180 && nextX < 270)
        {
            go_camera.transform.localEulerAngles = new Vector3(270, go_camera.transform.localEulerAngles.y, go_camera.transform.localEulerAngles.z);
        }
        else
        {
            go_camera.transform.Rotate(dx, 0, 0);
        }

        /*
        if (go_camera.transform.localEulerAngles.x < 275 && go_camera.transform.localEulerAngles.x >= 270)
        {
            go_camera.transform.localEulerAngles = new Vector3(275, go_camera.transform.localEulerAngles.y, go_camera.transform.localEulerAngles.z);
        }
        if (go_camera.transform.localEulerAngles.x > 85 && go_camera.transform.localEulerAngles.x <= 90)
        {
            go_camera.transform.localEulerAngles = new Vector3(85, go_camera.transform.localEulerAngles.y, go_camera.transform.localEulerAngles.z);
        }
        */

        /*
        if (go_camera.transform.eulerAngles.x > 275)
        {
            Debug.Log("Triiger 1");
            //go_camera.transform.SetPositionAndRotation(go_camera.transform.position, new Quaternion((float) (Math.PI / 2), 0, 0, 0));
            //go_camera.transform.rotation
            //go_camera.transform.rotation = Quaternion.Euler(90, 0, 0);
            
        } else
        {
            go_camera.transform.eulerAngles = new Vector3(275, 0, 0);
        }
        if (go_camera.transform.eulerAngles.x < 85)
        {
            Debug.Log("Triiger 2");
            
            //go_camera.transform.SetPositionAndRotation(go_camera.transform.position, new Quaternion(- (float) (Math.PI / 2), 0, 0, 0));
            //go_camera.transform.SetPositionAndRotation(go_camera.transform.position, new Quaternion(-90, 0, 0, 0));
            //go_camera.transform.rotation = Quaternion.Euler(-90, 0, 0);
        } else
        {
            go_camera.transform.eulerAngles = new Vector3(85, 0, 0);
        }
        
        //go_camera.transform.localRotation = Quaternion.Euler(90, go_camera.transform.localEulerAngles.y, go_camera.transform.localEulerAngles.z);
        */
    }
}
