using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject preGameUI;
    public GameObject gameUI;
    public GameObject postGameUI;
    //car colour:
    public GameObject carBody;
    private const float rDefault = 0.960784f, gDefault = 0.72549f, bDefault = 0.258824f;
    private Material colourMat;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        postGameUI.SetActive(false);
        gameUI.SetActive(false);
        preGameUI.SetActive(true);
        setCarColour();
    }

    private void setCarColour()
    {
        float r, g, b;

        colourMat = carBody.GetComponent<Renderer>().sharedMaterials[1];

        if (PlayerPrefs.GetFloat("playerR") == 0 && PlayerPrefs.GetFloat("playerG") == 0 && PlayerPrefs.GetFloat("playerB") == 0)
        {
            r = rDefault;
            g = gDefault;
            b = bDefault;
        }
        else
        {
            r = PlayerPrefs.GetFloat("playerR");
            g = PlayerPrefs.GetFloat("playerG");
            b = PlayerPrefs.GetFloat("playerB");
        }

        Color colour = new Color(r, g, b);
        colourMat.SetColor("_Color", colour);
    }

    public void StartGame(){
        GameObject start = GameObject.Find("RaceCarWithTouch");
        GameObject startBot = GameObject.Find("RaceCarBot");

        if(!start){
            return;
        }

        startBot.GetComponent<CarBotMovement>().setRunning(true);
        preGameUI.SetActive(false);
        start.GetComponent<CarMovement>().setRunning(true);
        gameUI.SetActive(true);
    }

    public void Back ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
