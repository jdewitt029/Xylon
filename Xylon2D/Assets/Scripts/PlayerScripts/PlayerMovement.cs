using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    //new stuff
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    // Update is called once per frame
    void Update()
    {

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


    void FixedUpdate ()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
