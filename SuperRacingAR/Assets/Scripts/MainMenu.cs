using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, howToPlay, about;
    
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        menu.SetActive(true);
        howToPlay.SetActive(false);
        about.SetActive(false);
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

    public void HowToPLay()
    {
        menu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void About()
    {
        menu.SetActive(false);
        about.SetActive(true);
    }

    public void Return()
    {
        about.SetActive(false);
        howToPlay.SetActive(false);
        menu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
