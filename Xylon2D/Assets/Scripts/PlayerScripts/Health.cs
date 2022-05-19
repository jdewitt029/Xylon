using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    private Animator animator;

    private int currentScene;

    private bool dead;

    //public int enHealth;

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
                //if (currentHealth < 1)
                {
                    //trigger death animation 
                    animator.SetTrigger("dies");
                    //calculates current scene to reload after death
                   
                    LevelManager.instance.GameOver();

                    

                    //gameObject.SetActive(false);

                    //Destroy(gameObject);
                   
                }
                if(GetComponent<Patrol>() != null)
                {
                    GetComponent<Patrol>().enabled = false;
                    GetComponent<enemyMelee>().enabled = false;
                }



                dead = true;
            }
            
        }
        
    }

    private void Update()
    {
        //enHealth = Boss.instance.getHealth();

        //if (enHealth = 0)
        //{
        //    stopReading;
        //}

        //Debug.Log(enHealth);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

        if (dead)
        {
            GetComponent<PlayerMovement>().enabled = false;
            
        }

        
    }

}
