using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class weapon : MonoBehaviour
{
   

    public Transform firePoint;

    public GameObject ShurikenPrefab;

    public Animator animator;

  

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {

            
            Shoot();




            
        }

    }

    void Shoot()
    {

        Instantiate(ShurikenPrefab, firePoint.position, firePoint.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("Attack");

        
    }

    //void Timer()
    //{

    //    if (time <= 0)
    //    {
    //        animator.SetBool("isAttack", false);
    //        time = 1;



    //    }
    //    else
    //    {
    //        //currentTime = currentTime - (100 * Time.deltaTime);
    //        time -=1 ;
    //        animator.SetBool("isAttack", true);
    //    }

//}
   

}
