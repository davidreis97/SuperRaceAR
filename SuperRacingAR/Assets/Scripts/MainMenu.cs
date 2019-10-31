using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    /*
     * Buttons' Functions
     * */
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EditCar()
    {
        SceneManager.LoadScene("EditCar");
    }

    public void howToPLay()
    {

    }

    public void About()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
