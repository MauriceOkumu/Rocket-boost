using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals 
{
    [SerializeField]
    public static float thrust = 1000f, rotationThrust = 100f;
    [SerializeField]
    public static float period = 10f;
    public static float distanceToMove = 10f;
    public static Vector3  movementVector = Vector3.right * Globals.distanceToMove;
}
