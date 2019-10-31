using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColourPicker : MonoBehaviour
{
    public GameObject carBody;
    private const float rDefault = 0.960784f, gDefault = 0.72549f, bDefault = 0.258824f;
    private Material colourMat;
    private float cR, cG, cB;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        colourMat = carBody.GetComponent<Renderer>().sharedMaterials[1];
        
        if (PlayerPrefs.GetFloat("playerR") == 0 && PlayerPrefs.GetFloat("playerG") == 0 && PlayerPrefs.GetFloat("playerB") == 0)
        {
            cR = rDefault;
            cG = gDefault;
            cB = bDefault;
            ApplyColour();
        }
        else
        {
            cR = PlayerPrefs.GetFloat("playerR");
            cG = PlayerPrefs.GetFloat("playerG");
            cB = PlayerPrefs.GetFloat("playerB");
        }

        PreviewColour(cR, cG, cB);
    }

    void PreviewColour(float r, float g, float b)
    {
        cR = r;
        cG = g;
        cB = b;
        Color colour = new Color(r, g, b);
        colourMat.SetColor("_Color", colour);
    }

    public void TryColour(string colour)
    {
        switch (colour)
        {
            case "black":
                PreviewColour(0.2666667f, 0.2666667f, 0.2666667f);
                break;
            case "blue":
                PreviewColour(0.2980392f, 0.3764706f, 0.4666667f);
                break;
            case "brown":
                PreviewColour(0.8313726f, 0.654902f, 0.4235294f);
                break;
            case "green":
                PreviewColour(0.3019608f, 0.5607843f, 0.4313726f);
                break;
            case "red":
                PreviewColour(0.9098039f, 0.3333333f, 0.3254902f);
                break;
            case "white":
                PreviewColour(0.945098f, 0.9490196f, 0.9647059f);
                break;
            case "yellow":
                PreviewColour(0.9607843f, 0.7254902f, 0.2588235f);
                break;
            case "reset":
                PreviewColour(PlayerPrefs.GetFloat("playerR"), PlayerPrefs.GetFloat("playerG"), PlayerPrefs.GetFloat("playerB"));
                break;
        }
    }

    public void ApplyColour()
    {
        PlayerPrefs.SetFloat("playerR", cR);
        PlayerPrefs.SetFloat("playerG", cG);
        PlayerPrefs.SetFloat("playerB", cB);
    }

    public void backToTheMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
