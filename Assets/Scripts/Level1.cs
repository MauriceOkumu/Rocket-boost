using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    
    void Awake()
    {
        Globals.distanceToMove = 20f;
        Globals.thrust = 1000f;
        Globals.rotationThrust = 100f;
         Globals.movementVector = Vector3.right * Globals.distanceToMove;
    }
}
