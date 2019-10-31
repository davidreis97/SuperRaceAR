using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject preGame;
    public GameObject game;
    public GameObject postGame;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        postGame.SetActive(false);
        game.SetActive(false);
        preGame.SetActive(true);
    }

    public void StartGame(){
        GameObject start = GameObject.Find("RaceCarWithTouch");

        if(!start){
            return;
        }

        preGame.SetActive(false);
        start.GetComponent<CarMovement>().setRunning(true);
        game.SetActive(true);
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
