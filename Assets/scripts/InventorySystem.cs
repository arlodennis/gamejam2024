using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject held_item = null;
    private int held_item_id = -1;
    private int total_weapons = 0;
    public GameObject arsenal = null;
    private ArrayList weapon_list = new ArrayList();

    void Start()
    {
        if (arsenal)
        {
            total_weapons = arsenal.transform.childCount;
            for (int i = 0; i < arsenal.transform.childCount; i++)
            {
                arsenal.transform.GetChild(i).gameObject.SetActive(false);
                weapon_list.Add(arsenal.transform.GetChild(i).gameObject);
            }
            
        }
        if (held_item)
        {
            held_item.SetActive(true);
            if (arsenal && held_item.transform.IsChildOf(arsenal.transform))
            {
                for (int i = 0; i < arsenal.transform.childCount; i++)
                {
                    if (arsenal.transform.GetChild(i).gameObject == held_item)
                    {
                        held_item_id = i;
                        break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(total_weapons);
        //Debug.Log(Input.mouseScrollDelta.y > 0);
        if (Input.GetMouseButtonDown(0))
        {
            if (held_item.GetComponent<Weapon>())
            {
                held_item.GetComponent<Weapon>().Fire(gameObject);
                gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.GetComponent<MoveAntiGrav>().go_camera.transform.forward * held_item.GetComponent<Weapon>().knockback);
            }
        }
        if (held_item && arsenal && total_weapons > 1 && Input.mouseScrollDelta.y != 0)
        {
            //Debug.Log("YOOOOOOOOOOOOOOOOO");
            held_item.SetActive(false);
            if (Input.mouseScrollDelta.y > 0)
            { // Scroll up - ++
                held_item_id++;
                if (held_item_id == total_weapons)
                {
                    held_item_id = 0;
                }
                held_item = (GameObject) weapon_list[held_item_id];
                held_item.SetActive(true);
            }
            else if (Input.mouseScrollDelta.y < 0)
            { // Scroll down - --
                held_item_id--;
                if (held_item_id == -1)
                {
                    held_item_id = total_weapons - 1;
                }
                held_item = (GameObject)weapon_list[held_item_id];
                held_item.SetActive(true);
            }
        }
    }
}
