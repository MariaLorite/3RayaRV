using System;
using UnityEngine;
using static Zinnia.Pointer.ObjectPointer;

public abstract class Player : MonoBehaviour, IPlayerBehaviour
{
    public int PlayerNumber;
    public event Action<int> PlayerThrowRaycast;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangePlayerPlaying(EventData a)
    {
        if (a != null)
        {
            if(gameManager.LastPlayerTurn != PlayerNumber)
                PutChip(a.CollisionData.collider.transform.gameObject);
          
        }
    }

    public void PutChip(GameObject ficha)
    {
        ThrowRaycast(ficha);
    }

    void ThrowRaycast(GameObject ficha)
    {
        if (ficha != null)
        {
            Debug.Log(ficha.gameObject.transform.name);

            Ficha fichaClick = ficha.gameObject.GetComponent<Ficha>();

            if (fichaClick != null)
            {
                Debug.Log("FichaClick " + fichaClick);

                //Si la ficha está vacia cambia la forma de la ficha y el jugador
                if (fichaClick.fichaEstado == 0)
                {
                    ficha.gameObject.GetComponent<Ficha>().ChangePlayerShape(PlayerNumber);
                    OnPlayerThrowRaycast(PlayerNumber);
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


    void Update()
    {
      if(Input.GetKey(KeyCode.Space))
        {
            Despedir();
        }
    }


    void OnPlayerThrowRaycast(int playerNumber)
    {
        PlayerThrowRaycast?.Invoke(playerNumber);
    }


    protected abstract void Saludar();

    protected virtual void Despedir()
    {
        print("Adios Maria");
    }
}
