using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
