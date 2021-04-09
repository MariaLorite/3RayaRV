using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Interactables.Interactors;
using Zinnia.Action;
using static Zinnia.Pointer.ObjectPointer;

//https://www.youtube.com/watch?v=qTbXxSns-zE

public class GameManager : MonoBehaviour
{
    public int playerNumber = 1;
    public Player JugadorX;
    public Player JugadorY;
    [Space(10)]
    public GameObject playerX_text;
    public GameObject player0_text;
    public GameObject message;

    public InteractorFacade LeftInteractor;

    public List<GameObject> fichasTablero = new List<GameObject>();

    int casillasVacias = 0;

    public event Action<List<GameObject>,int> CheckWinnerEvent;

    private void Start()
    {
        JugadorX = new Player();
        JugadorY = new Player();
        playerX_text.SetActive(true);
        player0_text.SetActive(false);
    }

    void OnCheckWinnerEvent(List<GameObject> fichasTablero, int playerNumber)
    {
        CheckWinnerEvent?.Invoke(fichasTablero, playerNumber);
    }

    public void CheckForWinner()
    {
        Debug.Log("Check for Winner");
        OnCheckWinnerEvent(fichasTablero, playerNumber);
    }


    void CheckBoard()
    {
        for (int i = 0; i < fichasTablero.Count; i++)
        {
           if (fichasTablero[i].GetComponent<Ficha>().fichaEstado == 0)
            {
                casillasVacias++;
            }
        }
        if (casillasVacias == 0)
        {
            Debug.LogError("Tablas");
            message.GetComponent<Text>().text = "Tablas";
            ResetGame();
        }
        casillasVacias = 0;
    }


    public void ChangePlayerPlaying(EventData a)
    {
        if (a != null)
        {
            if (playerNumber == 1)
            {
                JugadorY.PutChip(playerNumber, a.CollisionData.collider.transform.gameObject);
                CheckForWinner();
                playerNumber = 2;
            }
            else
            {
                message.GetComponent<Text>().text = "No puede poner ficha, Turno Jugador 2";
            }
            ChangePlayerText();
            CheckBoard();
        }
    }

    public void ChangePlayerPlayingB(EventData a)
    {
        if (a != null)
        {
            if (playerNumber == 2)
            {
                JugadorX.PutChip(playerNumber, a.CollisionData.collider.transform.gameObject);
                CheckForWinner();
                playerNumber = 1;
            }
            else
            {
                message.GetComponent<Text>().text = "No puede poner ficha, Turno Jugador 1";
            }
            ChangePlayerText();
            CheckBoard();
        }
    }


    void ResetGame()
    {
        //Carga la escena desde el inicio
        SceneManager.LoadScene(1);
    }


    public void Winner()
    {
        Debug.LogError("Tenemos un ganador: el jugador " + playerNumber );
        message.GetComponent<Text>().text = ("Tenemos un ganador: el jugador" + playerNumber.ToString());
        //ResetGame();
    }


    void ChangePlayerText()
    {
        if (playerNumber == 1)
        {
            playerX_text.SetActive(true);
            player0_text.SetActive(false);
        } else
        {
            playerX_text.SetActive(false);
            player0_text.SetActive(true);
        }
    }
}
