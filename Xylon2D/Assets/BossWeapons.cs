using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapons : MonoBehaviour
{
    public Transform firePoint1;

    public Transform firePoint2;

    public Transform firePoint3;

    public GameObject bullets, rocks, spearSlash;

    public Animator animator;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            

    }

    public void ShootDarts()
    {
        
        {
            SoundManager.PlaySound("dartShot");
            animator.SetTrigger("darts");
            Instantiate(bullets, firePoint1.position, firePoint1.rotation);
           


        }


    }

    public void SpearThrust()
    {

        animator.SetTrigger("spear");
        Instantiate(spearSlash, firePoint2.position, firePoint2.rotation);
        SoundManager.PlaySound("spearThrust");



    }


    public void GroundStomp()
    {
        animator.SetTrigger("stomp");
        SoundManager.PlaySound("groundCrush");

        Instantiate(rocks, firePoint3.position, firePoint3.rotation);
        
        

    }




}


