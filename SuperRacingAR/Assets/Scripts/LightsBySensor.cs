using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightsBySensor : MonoBehaviour
{
    public int LightLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.EnableDevice(LightSensor.current);
    }

    // Update is called once per frame
    void Update()
    {
        if(LightSensor.current != null){
            if (LightSensor.current.enabled){
                LightLevel = (int) LightSensor.current.lightLevel.ReadValue();
            }
        }
    }
}
