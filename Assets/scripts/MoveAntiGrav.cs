using UnityEngine;

public class MoveAntiGrav : MonoBehaviour
{

    public float speed = 120;
    public float rotation_speed = 180;
    public float gravity = 4;
    public float jump_force = 20;
    public float shoot_force = 10;
    public float super_kick_multiplier = 4;
    private Rigidbody pc = null;
    private Vector3 direction = Vector3.zero;
    public GameObject go_camera = null;
    private bool kicking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!pc) pc = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //transform.Translate(0, -1 * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime, 0);

        //float angle = Input.GetAxis("Mouse X") * rotation_speed * Time.deltaTime;
        //transform.Rotate(0, angle, 0);
        //Cursor.visible = false;
        transform.Rotate(Input.GetAxis("Vertical") * speed * Time.deltaTime, Input.GetAxis("Mouse X") * rotation_speed * Time.deltaTime, -Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        float dx = -Input.GetAxis("Mouse Y") * rotation_speed * Time.deltaTime;
        float nextX = go_camera.transform.localEulerAngles.x + dx;

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

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("CLICK");
            //pc.AddForce(-go_camera.transform.forward * shoot_force);
        }

        /*
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
        */
    }

    private void FixedUpdate()
    {
        kicking = false;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAA");

        if (!kicking && Input.GetButton("Jump"))
        {
            pc.AddForce(go_camera.transform.forward * jump_force * (Input.GetKey(KeyCode.LeftShift) ? super_kick_multiplier : 1));
            kicking = true;
        }
    }
}
