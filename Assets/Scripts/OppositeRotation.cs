using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * Globals.speed * 2);
    }
}
