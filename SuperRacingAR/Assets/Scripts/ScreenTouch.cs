using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rightOrLeft = 0;

        for(int i = 0; i < Input.touchCount; i++){
            Touch touch = Input.GetTouch(i);

            if(touch.position.x > (Screen.width / 2)){
                rightOrLeft++;
            }else{
                rightOrLeft--;
            }
        }

        if(rightOrLeft > 0){
            Debug.Log("Going right");
        }else if(rightOrLeft < 0){
            Debug.Log("Going left");
        }else{ //if(rightOrLeft == 0){
            Debug.Log("Going straight");
        }
    }
}
