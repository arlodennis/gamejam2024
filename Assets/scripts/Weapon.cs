using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fire_delay = 0;
    private float next_shot_delay = 0;
    public int bullet_count = 0;
    [Header("Buller Spread: +- degrees x, y")]
    public float[] bullet_spread = new float[2];
    public GameObject bullet = null;
    public float knockback = 0;
    public GameObject spawner = null;
    private Vector3 spawner_location = Vector3.zero;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawner)
        {
            spawner_location = spawner.transform.position;
        }
        else
        {
            spawner_location = gameObject.transform.position;
        }
    }

    
    //Update is called once per frame
    void Update()
    {
        if (spawner)
        {
            spawner_location = spawner.transform.position;
        }
        else
        {
            spawner_location = gameObject.transform.position;
        }
    }
    

    public void Fire(GameObject pc)
    {
        if (bullet && Time.time >= next_shot_delay)
        {
            for (int i = bullet_count; i > 0; i--)
            {
                GameObject newBullet = Instantiate(bullet, spawner_location, new Quaternion(transform.rotation.x + Random.Range(-bullet_spread[0] / 180 * Mathf.PI, bullet_spread[0] / 180 * Mathf.PI), transform.rotation.y + Random.Range(-bullet_spread[1] / 180 * Mathf.PI, bullet_spread[1] / 180 * Mathf.PI), transform.rotation.z, transform.rotation.w));
                //newBullet.GetComponent<Rigidbody>().angularVelocity = pc.GetComponent<Rigidbody>().angularVelocity;
            }
            next_shot_delay = Time.time + fire_delay;
        }
    }
}
