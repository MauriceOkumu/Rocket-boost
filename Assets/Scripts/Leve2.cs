using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leve2 : MonoBehaviour
{

    void Awake ()    
    {
        Globals.distanceToMove = 13f;
        Globals.period = 15f;
        Globals.thrust = 800f;
        Globals.rotationThrust = 150f;
        Globals.movementVector = Vector3.right * Globals.distanceToMove;
    }

}
