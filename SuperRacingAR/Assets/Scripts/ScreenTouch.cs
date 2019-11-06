using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    int IsRightOrLeft(float x)
    {
        if (x > (Screen.width / 2))
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public float GetInput()
    {
        int rightOrLeft = 0;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            rightOrLeft += IsRightOrLeft(touch.position.x);
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButton(0)) //Hack to make it work on the simulator as well
            {
                rightOrLeft += IsRightOrLeft(Input.mousePosition.x);
            }
        }


        if (rightOrLeft > 0)
        {
            return 1.0f;
        }
        else if (rightOrLeft < 0)
        {
            return -1.0f;
        }
        else
        {
            return 0.0f;
        }
    }
}
