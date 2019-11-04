using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, howToPlay, about, title;
    
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        menu.SetActive(true);
        title.SetActive(true);
        howToPlay.SetActive(false);
        about.SetActive(false);
    }

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
        title.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void About()
    {
        menu.SetActive(false);
        title.SetActive(false);
        about.SetActive(true);
    }

    public void Return()
    {
        about.SetActive(false);
        howToPlay.SetActive(false);
        menu.SetActive(true);
        title.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
