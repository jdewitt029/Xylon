using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    public int health = 100;

    public GameObject deathEffect;

    //bool dead = false;

    

    public Animator animator; 


    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;

        //animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            //animator.SetTrigger("isDying", true);
            //dead = true;
            Die();
            
        }
    }

   
    
    void Die()
    {

        //animator.SetBool("isDead", true);

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //animator.SetBool("isDying", false);
        //dead = false;

        Destroy(gameObject);
        


    }
}
