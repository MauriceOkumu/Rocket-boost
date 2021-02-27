using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leve2 : MonoBehaviour
{

    void Awake ()    
    {
        Globals.distanceToMove = 10f;
        Globals.thrust = 800f;
        Globals.rotationThrust = 150f;
        Globals.movementVector = Vector3.zero * Globals.distanceToMove;
    }

}
