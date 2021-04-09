using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Interactables.Interactors;
using UnityEngine;
using Zinnia.Action;
using static Zinnia.Pointer.ObjectPointer;

public class Player : IPlayerBehaviour
{
    int playerNumber = 1; //1 = X, 2 = 0;
    public InteractorFacade LeftInteractor;

    public void PutChip(int playerNumber, GameObject ficha)
    {
        ThrowRaycast(playerNumber, ficha);
    }

    void ThrowRaycast(int playerNumber, GameObject ficha)
    {
        if (ficha != null)
        {
            Debug.Log(ficha.gameObject.transform.name);
            Ficha fichaClick = ficha.gameObject.GetComponent<Ficha>();
            Debug.Log("FichaClick " + fichaClick);
            Debug.Log("PlayerNumber " + playerNumber);

            //Si la ficha está vacia cambia la forma de la ficha y el jugador
            if (fichaClick.fichaEstado == 0)
            {
                ficha.gameObject.GetComponent<Ficha>().ChangePlayerShape(playerNumber);
                //Cuando el rayo incida en un objecto que se cambie el jugador
            }
            else if (fichaClick.fichaEstado == 1)
            {
                Debug.Log("is X");
            }
            else if (fichaClick.fichaEstado == 2)
            {
                Debug.Log("is 0");
            }
        }
    }
}
