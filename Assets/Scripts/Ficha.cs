using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    public GameObject empty;
    public GameObject player1_X;
    public GameObject player2_0;
    [Space(10)]

    public int fichaEstado = 0;

    public void ChangePlayerShape(int playerNumber)
    {
        if (playerNumber == 1) // X
        {
            fichaEstado = 1; // X
            empty.SetActive(false);
            player1_X.SetActive(true);
        } else
        {
            fichaEstado = 2; // 0
            empty.SetActive(false);
            player2_0.SetActive(true);
        }
    }
}
