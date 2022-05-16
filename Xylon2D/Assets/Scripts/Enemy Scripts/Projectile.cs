using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour


{

    private Health playerHealth;
    //private PlayerMovement player;
    private CharacterController2D player;
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
        rb.velocity = -transform.right * speed;


    }

    // void OnCollisionEnter2D(Collision2D col)
    //{

    //    if (player != null) 
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log(col);
    //        playerHealth.TakeDamage(1);

    //    }
    //}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        playerHealth = hitInfo.GetComponent<Health>();


        if (hitInfo.gameObject.CompareTag("Player"))
            {
           
            Destroy(gameObject);
            playerHealth.TakeDamage(damage);

        }

        //Enemy enemy = hitInfo.GetComponent<Enemy>();

        //if (enemy != null)
        //{
        //    Debug.Log(hitInfo.name);
        //    //Destroy(gameObject);
        //    //enemy.TakeDamage(damage);

        //}


        //if (collision.tag == "enemy")




    }



}
