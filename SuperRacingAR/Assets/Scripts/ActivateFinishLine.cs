using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFinishLine : MonoBehaviour
{

    public GameObject endGameDetector;

    public int numberOfLaps = 1;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Car"){
            numberOfLaps--;
            if(numberOfLaps <= 0){
                Instantiate(endGameDetector,transform.parent);
            }
        }
    }
}
