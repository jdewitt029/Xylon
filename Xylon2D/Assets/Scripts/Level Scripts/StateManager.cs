using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
   

    public void ReloadCurrentScene()
    {
        //calculates current scene to reload after death
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ChangeSceneByName(string name)
{
    if (name != null) {
        //loads menu
        SceneManager.LoadScene(name);
    }
}

}

