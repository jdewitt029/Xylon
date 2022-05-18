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

            //ShootDarts();

    }

    public void ShootDarts()
    {

        Instantiate(bullets, firePoint1.position, firePoint1.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("darts");


    }

    public void SpearThrust()
    {

        Instantiate(spearSlash, firePoint2.position, firePoint2.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("spear");


    }


    public void GroundStomp()
    {

        Instantiate(rocks, firePoint2.position, firePoint2.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("stomp");


    }




}


