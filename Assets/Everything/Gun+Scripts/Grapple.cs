using System;
using Unity.VisualScripting;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public int Cooldown = 5;
    private float cooldownTimer = 0;
    public GameObject pc;
    Vector3 CalculateDistance;
    Boolean isGrappling = false;
    RaycastHit wall;

    public GameObject Rope;
    GameObject clone;
    
    Camera Cam;

    void Start()
    {
        //Cooldown = 5;
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();  
    }


    void Update()
    {
        //if (Input.GetMouseButtonDown(1) && !isGrappling)
        if (Input.GetKeyDown(KeyCode.Q) && !isGrappling)
        {
            FireGrapple();
        }
        if (isGrappling)
        {
            MovePCtoGrapple(CalculateDistance);
        }
    }

  void FireGrapple()
    {
        //if (Cooldown == 5)
        if (Time.time >= cooldownTimer)
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out  wall, 100f))
            {
                isGrappling = true;
             
                CalculateDistance = wall.point;
                spawnropeonhit(CalculateDistance);
            }
        }
    }

    void MovePCtoGrapple(Vector3 distance)
    {
      
        pc.transform.position = Vector3.MoveTowards(pc.transform.position, distance, 75 * Time.deltaTime);
        clone.transform.localScale = new Vector3(clone.transform.localScale.x, clone.transform.localScale.y, Vector3.Distance(distance, pc.transform.position));
        
        //print(Vector3.Distance(distance, pc.transform.position));
        if (Vector3.Distance(distance, pc.transform.position) <= 2)
        {
            isGrappling = false;
            CalculateDistance = Vector3.zero;
            Destroy(clone);
            clone = null;
            cooldownTimer = Time.time + Cooldown;
        }
    }

    void spawnropeonhit(Vector3 pointToGo)
    {
        if (isGrappling)
        {
            

            //clone = Instantiate(Rope, pointToGo, new Quaternion(Cam.transform.forward.x, Cam.transform.forward.y, Cam.transform.forward.z, 0));
            //clone = Instantiate(Rope, Cam.gameObject.transform.position, new Quaternion(Cam.transform.forward.x, Cam.transform.forward.y, Cam.transform.forward.z, 0));
            clone = Instantiate(Rope, pointToGo, new Quaternion(Cam.transform.forward.x, Cam.transform.forward.y, Cam.transform.forward.z, 0));
            clone.transform.LookAt(new Vector3(Cam.gameObject.transform.position.x, Cam.gameObject.transform.position.y - 1, Cam.gameObject.transform.position.z));
            //Debug.Log(clone.transform.scal);
            //clone.transform.localScale = new Vector3(clone.transform.lossyScale.x * 1, clone.transform.lossyScale.y + 0.1f, clone.transform.lossyScale.z);
            
            
        }

    }



}
