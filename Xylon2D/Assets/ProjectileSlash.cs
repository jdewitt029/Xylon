using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSlash : MonoBehaviour
{
    private Health playerHealth;
    //private PlayerMovement player;
    //private CharacterController2D player;
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
        rb.velocity = -transform.right * speed;


    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        playerHealth = hitInfo.GetComponent<Health>();


        if (hitInfo.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("damaged");
            Destroy(gameObject);

            playerHealth.TakeDamage(damage);

        }

    }
}
