using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Referee : MonoBehaviour
{

    [SerializeField] Man player1;
    [SerializeField] Man player2;
    [SerializeField] bool player2Enabled = false;
    bool gameOver = false;
    string winner = "";
    float winnerMessageDelay = 1.5f;
    Man playersTurn;


    void Update()
    {

        if(gameOver){return;}

        if (player1.GetLives() == 0){
            winner = player2.playerName + " wins!!!";
            gameOver = true;
        } 
        
        if (player2.GetLives() == 0){
            winner = player1.playerName + " wins!!!"; 
            gameOver = true;
        }

        if(gameOver){
            StartCoroutine(BackToMainMenu());
        }

        SetPlayersTurn();

    }

    IEnumerator BackToMainMenu(){
        yield return new WaitForSecondsRealtime(winnerMessageDelay);
        SceneManager.LoadScene(0);
    }

    void SetPlayersTurn(){
        if ((player1.GetNumOfShots() + player2.GetNumOfShots()) % 2 == 1){
            if(player2Enabled){
                playersTurn = player2;
                player1.GetComponentInChildren<Bow>().enabled = false;
                player2.GetComponentInChildren<Bow>().enabled = true;
            }
        } else {
            playersTurn = player1;
            player1.GetComponentInChildren<Bow>().enabled = true;
            player2.GetComponentInChildren<Bow>().enabled = false;
        }
    }

    public Man GetPlayersTurn(){
        return playersTurn;
    }
    
}
