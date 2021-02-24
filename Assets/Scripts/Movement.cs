using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float thrust = 1000f, rotationThrust = 100f;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {

            audioSource.Play();
        
            }
        }else{
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.LeftArrow))
        {
             ApplyRotation(-rotationThrust);
        }
         else if(Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(rotationThrust);
        }

    }
    void ApplyRotation(float rotateThis)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * rotateThis * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
           
