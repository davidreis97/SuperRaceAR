using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[Serializable]
public class Weather
{
    public int id;
    public string main;
}

[Serializable]
public class WeatherInfo
{
    public int id;
    public string name;
    public List<Weather> weather;
}

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "666bb7b51e8a57bfa03324b03ba1d35c";
    private const float API_CHECK_MAXTIME = 10 * 60.0f;     // 10 minutes
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    public string CityID = "2735941";    // Distrito do Porto
    public GameObject ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeather(CheckWeather));
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckWeather));
        }
    }

    public void CheckWeather(WeatherInfo weatherObj)
    {
        //bool snowing = weatherObj.weather[0].main.Equals("Snow");
        //if (snowing)
        //    ParticleSystem.SetActive(true);
        //else
        //ParticleSystem.SetActive(false);

        int weatherID = weatherObj.weather[0].id;

        Debug.Log("BOAS");
        Debug.Log(weatherObj.weather[0].id);
    }

    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityID, API_KEY)))
        {
            yield return req.SendWebRequest();
            while (!req.isDone)
                yield return null;
            byte[] result = req.downloadHandler.data;
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
            onSuccess(info);
        }
    }
}
