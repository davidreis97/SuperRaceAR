using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(){
        GameObject start = GameObject.Find("RaceCarWithTouch");

        if(!start){
            return;
        }

        start.GetComponent<CarMovement>().setRunning(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
