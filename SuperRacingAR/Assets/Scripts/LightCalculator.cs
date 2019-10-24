using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCalculator : MonoBehaviour
{
    LightsBySensor lbs;
    Light spotlight;
    public float intensityMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        lbs = GameObject.Find("LightController").GetComponent<LightsBySensor>();
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lbs != null && lbs.LightLevel > 0){
            if(spotlight != null){
                spotlight.intensity = (1 - ((float) lbs.LightLevel/500f)) * intensityMultiplier;
            }
        }
    }
}
