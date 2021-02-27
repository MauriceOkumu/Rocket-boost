using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocsillator : MonoBehaviour
{
    Vector3 startingPos;
    // Vector3  movementVector;
    float movementFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        // Globals.movementVector = Vector3.right * Globals.distanceToMove;
        // Debug.Log("Distance to move " + Globals.distanceToMove);
    }

    void Update()
    {
        if(Globals.period <= Mathf.Epsilon) return;// Protect against NaN with floats
        float cycles = Time.time / Globals.period;// continually grow
        const float tau = Mathf.PI * 2;//constant value
        float sineWave = Mathf.Sin(cycles * tau);//going from -1 to 1
        movementFactor = (sineWave + 1f) / 2f;//recalculated to go from 0 to 1
        Vector3 offset = Globals.movementVector * movementFactor;
       transform.position = startingPos + offset;//transform the position in any axis

    }
}
