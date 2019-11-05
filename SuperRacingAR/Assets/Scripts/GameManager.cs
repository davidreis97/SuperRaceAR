using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject preGameUI;
    public GameObject gameUI;
    public GameObject postGameUI;
    public GameObject playerWon;
    public GameObject botWon;
    //car colour:
    public GameObject carBody;
    private const float rDefault = 0.960784f, gDefault = 0.72549f, bDefault = 0.258824f;
    private Material colourMat;
    //game timer
    [SerializeField] private Text Countdown;
    private bool runTimer = false, canCount = false, doOnce = false;
    private float mainTimer = 3.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        postGameUI.SetActive(false);
        gameUI.SetActive(false);
        preGameUI.SetActive(true);
        setCarColour();
        timer = mainTimer;
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

    public void StartGame()
    {
        preGameUI.SetActive(false);
        gameUI.SetActive(true);
        runTimer = true;
        canCount = true;

    }

    public void FinishGame(Winner winner){

        if(winner == Winner.Bot){
            botWon.SetActive(true);
        }else if(winner == Winner.Player){
            playerWon.SetActive(true);
        }

        gameUI.SetActive(false);
        postGameUI.SetActive(true);

        GameObject start = GameObject.Find("RaceCarWithTouch");
        GameObject startBot = GameObject.Find("RaceCarBot");
        startBot.GetComponent<CarBotMovement>().setRunning(false);
        start.GetComponent<CarMovement>().setRunning(false);

        Debug.Log("Finished the game");
    }

    public void Back ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (runTimer)
        {
            timer -= Time.deltaTime;
            if (timer > 0.0f && canCount)
            {
                Countdown.text = timer.ToString("F");
            }
            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                Countdown.text = "GO!";
                timer = 0.0f;

                GameObject start = GameObject.Find("RaceCarWithTouch");
                GameObject startBot = GameObject.Find("RaceCarBot");
                startBot.GetComponent<CarBotMovement>().setRunning(true);
                start.GetComponent<CarMovement>().setRunning(true);
            }
            else if (!canCount && doOnce && timer <= 0.0f)
            {
                Countdown.CrossFadeAlpha(0.0f, 0.5f, false);
            }
        }
    }
}
