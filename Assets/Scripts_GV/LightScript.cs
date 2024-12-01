using UnityEngine;

public class LightScript : MonoBehaviour
{
    private GameObject[] lightArray;
    private int lightsCount;
    public GameObject lightsList;
    private int redColourChangeValue = 5;
    private int currentRedValue = 255;
    private int intensityChange = 5;

    void Start()
    {
  
      lightsCount = lightsList.transform.childCount;
      lightArray = new GameObject[lightsCount];
       
        for(int i = 0; i < lightsCount; i++)
        {
            lightArray[i] = lightsList.transform.GetChild(i).gameObject;
            lightArray[i].transform.GetChild(0).GetComponent<Light>().intensity = 60;
            lightArray[i].transform.GetChild(0).GetComponent<Light>().spotAngle += 20;
        }
    }

    //Changing the colour and intesnity of the lights as player health goes down
    void Update()
    {
        changeColourOfLights();
        makeLightsFlicker();
    }

    void changeColourOfLights()
    {
        if (Input.GetKey(KeyCode.A))
        {
            for (int i = 0; i < lightsCount; i++)
            {
                lightArray[i].transform.GetChild(0).GetComponent<Light>().color = Color.red;
                lightArray[i].transform.GetChild(0).GetComponent<Light>().intensity = 200;
                lightArray[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            }
        }
    }

    void makeLightsFlicker()
    {
        int randNum = Random.Range(0, 50);
        for (int i = 0; i < lightsCount; i++)
        {
            if (i == randNum)
            {
                lightArray[i].transform.GetChild(0).GetComponent<Light>().intensity = 0;
                lightArray[i].transform.GetChild(0).GetComponent<Light>().intensity = 60;

            }
        }
    }

}
