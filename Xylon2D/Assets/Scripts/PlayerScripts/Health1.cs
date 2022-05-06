using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    private Animator animator;

    private int currentScene;

    private bool dead;

    


    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                //player
                if (GetComponent<PlayerMovement>() != null)

                {

                    //trigger death animation 
                    //animator.SetBool("isDead", true);

                    animator.SetTrigger("dies");


                  
                    //currentScene = SceneManager.GetActiveScene().buildIndex;
                    LevelManager.instance.GameOver();

                    gameObject.SetActive(false);

                    Destroy(gameObject);


                    //LevelManager.instance.Respawn();


                }
                if(GetComponent<Patrol>() != null)
                {
                    GetComponent<Patrol>().enabled = false;
                    GetComponent<enemyMelee>().enabled = false;
                }

               
                dead = true;

               
            }

            //reloadScene();

        }


       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

  

}
