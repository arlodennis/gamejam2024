using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;
    public float rotation_speed = 180;
    public float gravity = 4;
    public float jump_force = 20;
    private CharacterController pc = null;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(0, -1 * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime, 0);
        //this.transform.position += new Vector3(0.1f, 0.1f, 0.1f);
        //Debug.Log(pc.isGrounded);

        float angle = Input.GetAxis("Mouse X") * rotation_speed * Time.deltaTime;
        transform.Rotate(0, angle, 0);

        if (pc.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = speed * transform.TransformDirection(direction);

            if (Input.GetButton("Jump")) direction.y = jump_force;
        }
        else
        {
            direction.y -= gravity * Time.deltaTime;
        }
        pc.Move(direction * Time.deltaTime);
    }
}
