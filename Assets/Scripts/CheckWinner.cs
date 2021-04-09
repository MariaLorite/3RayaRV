using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        gameManager.CheckWinnerEvent += OnCheckWinnerEvent;
    }

    private void OnDisable()
    {
        gameManager.CheckWinnerEvent -= OnCheckWinnerEvent;
    }

    private void OnCheckWinnerEvent(List<GameObject> fichasTablero, int playerNumber)
    {
        Debug.Log("He entrado en el evento");
        //Comprobacion en horizontal
        if (fichasTablero[0].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[1].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[2].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        if (fichasTablero[3].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[4].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[5].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        if (fichasTablero[6].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[7].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[8].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        //Comprobacion en vertical
        if (fichasTablero[0].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[3].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[6].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        if (fichasTablero[1].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[4].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[7].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        if (fichasTablero[2].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[5].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[8].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        //Comprobacion en diagonal
        if (fichasTablero[0].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[4].GetComponent<Ficha>().fichaEstado == playerNumber &&
            fichasTablero[8].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
        if (fichasTablero[2].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[4].GetComponent<Ficha>().fichaEstado == playerNumber &&
           fichasTablero[6].GetComponent<Ficha>().fichaEstado == playerNumber)
        {
            gameManager.Winner();
        }
    }
}
