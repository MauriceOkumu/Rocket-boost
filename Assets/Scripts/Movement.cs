using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    float thrust = 1000f, rotationThrust = 100f;
    [SerializeField]
    ParticleSystem leftBooster, mainBooster, rightBooster;

    [SerializeField] 
    AudioClip booster, sideBooster;

    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Boost();
        }else{
           StopBoost();
        }
    }
    void Boost()
    {
        if(!mainBooster.isPlaying) mainBooster.Play();
           
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
            audioSource.PlayOneShot(booster);
            }
    }
    void StopBoost()
    {
        audioSource.Stop();
        mainBooster.Stop();
    }
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
         else if(Input.GetKey(KeyCode.RightArrow))
        {
           RotateRight();
        }else{
            StopRotation();
        }

    }
    void ApplyRotation(float rotateThis)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * rotateThis * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void RotateLeft()
    {
        if(!leftBooster.isPlaying) leftBooster.Play();
        if(!audioSource.isPlaying) audioSource.PlayOneShot(sideBooster);
        ApplyRotation(-rotationThrust);
    }
    void RotateRight()
    {
        if(!rightBooster.isPlaying) rightBooster.Play();
        if(!audioSource.isPlaying) audioSource.PlayOneShot(sideBooster);
        ApplyRotation(rotationThrust);
    }
    void StopRotation()
    {
        leftBooster.Stop();
        rightBooster.Stop();
    }
}
        
           

