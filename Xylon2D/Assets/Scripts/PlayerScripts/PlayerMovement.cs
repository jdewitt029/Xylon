using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    [SerializeField] private float damageCooldown;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    private Health playerHealth;

    bool jump = false;

    private float cooldownTimer = Mathf.Infinity;

    //new stuff



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
    }

  

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

       

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat ("Speed", Mathf.Abs(horizontalMove));
       

        if (Input.GetButtonDown("Jump"))
        {
            SoundManager.PlaySound("jump");

            animator.SetBool("isJumping", true);
            jump = true;

        }


    }

    
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

       


            //attack

            if (col.gameObject.CompareTag("fish"))
            {
                if (cooldownTimer >= damageCooldown)
                {

                    cooldownTimer = 0;

                    SoundManager.PlaySound("poisoned");

                    playerHealth.TakeDamage(1);

                }
        }
    }


    void FixedUpdate ()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
