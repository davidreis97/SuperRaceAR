using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Winner{Player, Bot}

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Car"){
            fireworks.Play();

            Winner winner;

            if(col.GetComponent<CarBotMovement>() != null){
                winner = Winner.Bot;
            }else{
                winner = Winner.Player;
            }

            gameManager.FinishGame(winner);
        }
    }

}
