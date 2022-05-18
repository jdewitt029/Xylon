using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    public int health = 100;

    [SerializeField] private BoxCollider2D box;

    public Animator animator; 



    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
       
           SoundManager.PlaySound("enemyDamaged");
           health -= damage;
        
        //animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            //dead = true;
            
            //animator.SetBool("dead", true);

            Die();
            
        }
    }

   
    
    void Die()
    {

        //animator.SetBool("isDead", true);

        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        //animator.SetBool("isDying", false);
        animator.SetTrigger("death");

        GetComponent<Patrol>().enabled = false;
        GetComponent<FishEnemy>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        box.GetComponent<BoxCollider2D>().enabled = false;



        //body.SetActive(false);

        //Destroy(gameObject);



    }
}
