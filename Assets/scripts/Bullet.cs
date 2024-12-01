using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 0;
    public float speed = 0;
    public string[] exclude_tags = {"Bullet"};

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collision!!!");
        //if (collision.gameObject.GetComponent<Health_Script>)
        //{
        //
        //}
        bool friend = false;
        foreach (string tag in exclude_tags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                friend = true;
                break;
            }
        }
        if (!friend)
        {
            Destroy(gameObject);
        }
    }
}
