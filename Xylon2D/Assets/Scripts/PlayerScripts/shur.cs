using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shur : MonoBehaviour

    
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            //Debug.Log(hitInfo.name);
            Destroy(gameObject);
            enemy.TakeDamage(damage);

        }

        Boss boss = hitInfo.GetComponent<Boss>();

        if (boss != null)
        {
            //Debug.Log(hitInfo.name);
            Destroy(gameObject);
            boss.TakeDamage(damage);

        }


        //if (collision.tag == "enemy")




    }
   
}
