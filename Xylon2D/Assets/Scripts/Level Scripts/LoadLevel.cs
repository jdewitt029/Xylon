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

    public BossHealth instance;

    private int healthCheck;



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

        //healthCheck = instance.getHealth();



        levelCheck = SceneManager.GetActiveScene().buildIndex;

        //Debug.Log(healthCheck);

        if (levelCheck == 8)
        {
            if (collisionGameObject.tag == "Player" && instance.getHealth() <= 0)
            {
                //Debug.Log(enemyHealth);
                SceneManager.LoadScene(iLevelToLoad);
            }
        }

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
