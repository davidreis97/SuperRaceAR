using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMapDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CarMovement cm = (CarMovement)other.gameObject.GetComponent("CarMovement");
        cm.slowDownSpeed();
    }

    private void OnTriggerExit(Collider other)
    {
        CarMovement cm = (CarMovement)other.gameObject.GetComponent("CarMovement");
        cm.resetSpeed();
    }
}
