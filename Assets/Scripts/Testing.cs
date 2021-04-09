using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Interactables.Interactors;
using UnityEngine;
using Zinnia.Action;
using static Zinnia.Pointer.ObjectPointer;

public class Testing : MonoBehaviour
{
    public InteractorFacade LeftInteractor;

    public float GrabbingDistance;
   
    //public BooleanAction action;

    ////public void Activated(bool a)
    ////{
    ////    print(a);
    ////}

    ////public void Hi()
    ////{
    ////    print("Hola");
    ////}

    ////public void Bye()
    ////{
    ////    print("Adios");
    ////}

    //private void Update()
    //{
    //    //if(Input.GetKey(KeyCode.JoystickButton14))
    //    //{
    //    //    print("Getted");
    //    //}

    //    //if (Input.GetKey(KeyCode.Space))
    //    //{
    //    //    print("Getted1");
    //    //}

        
    //}

    public void test(EventData a)
    {
        if (a != null)
        {
            float distance = 0;
            distance = Vector3.Distance(LeftInteractor.transform.position, a.CollisionData.collider.transform.position);
            Debug.Log(distance);

            if (distance <= 5)
            {
                //a es el Rayo. 
                a.CollisionData.collider.transform.GetComponentInParent<InteractableFacade>().Grab(LeftInteractor);
            }
            else
            {
                Debug.Log("Acercate más al Cubo");
            }
        }

        //if(a != null)
        //{
        //    var _collidedObject = a.CollisionData.collider.transform;
        //    var _distance = Vector3.Distance(a.Transform.position, _collidedObject.position);

        //    if(_distance <= GrabbingDistance)
        //    {
        //        _collidedObject.GetComponentInParent<InteractableFacade>().Grab(LeftInteractor);
        //    }
        //}
    }
}

//namespace OculusIntegrationForVRTK.Input
//{
//    using Zinnia.Action;

//    public class Testing: BooleanAction
//    {
//        public OVRInput.Controller
//    }
//}
