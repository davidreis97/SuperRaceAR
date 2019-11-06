using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Winner { Player, Bot }

public class EndGame : MonoBehaviour
{
    public ParticleSystem fireworks;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        fireworks.Stop();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Car")
        {
            fireworks.Play();

            Winner winner = col.GetComponent<CarBotMovement>() != null ? Winner.Bot : Winner.Player;
            gameManager.FinishGame(winner);
        }
    }

}
