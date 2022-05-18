using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;
    [SerializeField] public int goldTotal;
    private int coinCheck;

    private int levelCheck;

    public bool useIntegerToLoadLevel = false;

    public int enemyHealth;
   

     void Start()
    {



    }


    void Update()
    {
        coinCheck = ScoreManager.instance.getScore();
        //enemyHealth = Boss.instance.getHealth();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject collisionGameObject = collision.gameObject;

        //levelCheck = SceneManager.GetActiveScene().buildIndex;

        //Debug.Log(levelCheck);

        //if (levelCheck == 8)
        //{
        //    if (collisionGameObject.tag == "Player" && enemyHealth <= 0)
        //    {
        //        SceneManager.LoadScene(iLevelToLoad);
        //    }
        //}

            if (collisionGameObject.tag == "Player" && coinCheck == goldTotal) 
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
