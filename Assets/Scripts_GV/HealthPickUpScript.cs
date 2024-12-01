using UnityEngine;
using UnityEngine.ProBuilder;

public class HealthPickUpScript : MonoBehaviour
{
    private float cooldown;
    private bool isActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooldown = 100f;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        respawnHealth();
        Debug.Log(cooldown);
    }

    void respawnHealth()
    {
        if(!isActive) { cooldown -= Time.deltaTime; }
        
        if ( cooldown <= 0.0f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            isActive = false;
            cooldown = 60f;
        }
    }
}
