using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   void OnCollisionEnter(Collision other) {
       switch (other.gameObject.tag)
       {
            case "Friendly":
                Debug.Log("Launch pad");
                break;
            case "Fuel":
                Debug.Log("Fueled");
                break;
            case "Finish":
                Debug.Log("Finished Level");
                 LoadNextLevel();
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
       GetComponent<Movement>().enabled = false;
       Invoke("ReloadLevel", 2f);
   }
}
