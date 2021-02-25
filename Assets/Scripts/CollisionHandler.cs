using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelDelay = 2f;

    [SerializeField] 
    AudioClip crashedSound, levelFinished;

    [SerializeField]
    ParticleSystem successParticles, crashParticles;

     AudioSource audioSource;

     bool inTransition = false;
     void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

   void OnCollisionEnter(Collision other) {
       if( inTransition) return;

       switch (other.gameObject.tag)
       {
            case "Friendly":
                Debug.Log("Launch pad");
                break;
            case "Finish":
                Debug.Log("Finished Level");
                 startSequence();
                break;
           default:
             Debug.Log("Life lost");
             CrashSequence();
             break;
       }
   }
   void ReloadLevel()
   {
       int currentIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentIndex);
   }
   void LoadNextLevel() 
   {
       int currentIndex = SceneManager.GetActiveScene().buildIndex;
       int nextScene = currentIndex + 1;
       if(nextScene == SceneManager.sceneCountInBuildSettings)
       {
           nextScene = 0;
       }
       SceneManager.LoadScene(nextScene);
   }
   void CrashSequence()
   {
        inTransition = true;
        audioSource.Stop();
       //Add SFX
       audioSource.PlayOneShot(crashedSound);
       //Add particle effect
        crashParticles.Play();
       GetComponent<Movement>().enabled = false;
       Invoke("ReloadLevel", levelDelay);
   }
   void startSequence()
   {
        inTransition = true;
        audioSource.Stop();
         successParticles.Play();
       audioSource.PlayOneShot(levelFinished);
       GetComponent<Movement>().enabled = false;
       Invoke("LoadNextLevel", levelDelay);
    
   }
}

