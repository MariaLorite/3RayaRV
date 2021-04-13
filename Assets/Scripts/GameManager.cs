using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

//https://www.youtube.com/watch?v=qTbXxSns-zE

public class GameManager : MonoBehaviour
{
    public int LastPlayerTurn = 1;

    public Player JugadorX;
    public Player JugadorY;

    [Space(10)]
    public GameObject playerX_text;
    public GameObject player0_text;
    public GameObject message;


    public List<GameObject> fichasTablero = new List<GameObject>();

    int casillasVacias = 0;

    public event Action<List<GameObject>,int> CheckWinnerEvent;


    private void OnEnable()
    {
        JugadorX.PlayerThrowRaycast += OnPlayerThrowRaycast;
        JugadorY.PlayerThrowRaycast += OnPlayerThrowRaycast;
    }

    private void OnDisable()
    {
        JugadorX.PlayerThrowRaycast -= OnPlayerThrowRaycast;
        JugadorY.PlayerThrowRaycast -= OnPlayerThrowRaycast;
    }

    private void Start()
    {
        playerX_text.SetActive(true);
        player0_text.SetActive(false);
    }

    public void Winner()
    {
        Debug.LogError("Tenemos un ganador: el jugador " + LastPlayerTurn);
        message.GetComponent<Text>().text = ("Tenemos un ganador: el jugador " + LastPlayerTurn.ToString());

        Invoke("ResetGame", 2.0f);
    }

    public void CheckForWinner()
    {
        Debug.Log("Check for Winner");
        OnCheckWinnerEvent(fichasTablero, LastPlayerTurn);
    }

    private void OnPlayerThrowRaycast(int obj)
    {
        LastPlayerTurn = obj;
        CheckForWinner();
        ChangePlayerText();
        CheckBoard();
    }


    void OnCheckWinnerEvent(List<GameObject> fichasTablero, int playerNumber)
    {
        CheckWinnerEvent?.Invoke(fichasTablero, playerNumber);
    }
    
    void ChangePlayerText()
    {
        if (LastPlayerTurn == 1)
        {
            playerX_text.SetActive(true);
            player0_text.SetActive(false);
        }
        else
        {
            playerX_text.SetActive(false);
            player0_text.SetActive(true);
        }
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

    void ResetGame()
    {
        //Carga la escena desde el inicio
        SceneManager.LoadScene(1);
    }



}
