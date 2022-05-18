using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;

    private int coinCheck;

    public bool useIntegerToLoadLevel = false;
   

     void Start()
    {



    }


    void Update()
    {
        coinCheck = ScoreManager.instance.getScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject collisionGameObject = collision.gameObject;

        




        if (collisionGameObject.tag == "Player" && coinCheck == 5 ) 
        {
            if (useIntegerToLoadLevel)
            {
                SceneManager.LoadScene(iLevelToLoad);
            }
            else
            {
                SceneManager.LoadScene(sLevelToLoad);
            }
        }        
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }
   
}
