using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public float rayDistance = 1f;
    public Animator animator;
    int rand;

   

    public int health = 100;

    [SerializeField] private PolygonCollider2D PolyCollide;
    [SerializeField] private BoxCollider2D boxCollide;
    [SerializeField] private float attackCooldown;

    private float cooldownTimer = Mathf.Infinity;

    private bool movingRight = true;

    

    public Transform groundDetection;

  
    void Start()
    {
      

    animator = GetComponent<Animator>();

    }

    private void Update()
    {

        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {

            RandomNumber();

            cooldownTimer = 0;
        }

        //Debug.Log(rand);


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }

    private void RandomNumber()
    {
        if (health > 750)
        {
            attackCooldown = 2;
            rand = Random.Range(1, 4);
            Debug.Log(rand);
            speed = 4;
            Attacks(rand);
        }
        else if (health > 500 && health <= 750)
        {

            attackCooldown = 2;
            rand = Random.Range(1, 8);
            speed = 7;
            //rand = 4;
            Debug.Log(rand);
            Attacks(rand);

        }
        else if (health > 250 && health <= 500)
        {
            attackCooldown = 2;
            rand = Random.Range(4, 8);
            Attacks(rand);
            speed = 10;
        }
        else
        {
            attackCooldown = 1.5f;
            rand = Random.Range(4, 9);
            Attacks(rand);
            speed = 12;
        }
    }
        

    public void TakeDamage(int damage)
    {

        SoundManager.PlaySound("enemyDamaged");
        health -= damage;

        //animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            
            Die();

        }
    }

    void Die()
    {


        Destroy(gameObject);


    }

    private void Attacks(int r)
    {
        Debug.Log(r);
        switch (r)
        {

            case 1:
                
                GetComponent<BossWeapons>().ShootDarts();
                break;
            case 2:
               
                GetComponent<BossWeapons>().SpearThrust();
                break;
            case 3:
                
                GetComponent<BossWeapons>().GroundStomp();
                break;
            case 4:
                GetComponent<BossWeapons>().GroundStomp();
                GetComponent<BossWeapons>().SpearThrust();
                
                break;
            case 5:
                GetComponent<BossWeapons>().GroundStomp();
                GetComponent<BossWeapons>().ShootDarts();
                
                break;
            case 6:
                GetComponent<BossWeapons>().SpearThrust();
                GetComponent<BossWeapons>().ShootDarts();
                
                break;
            case 7:
                GetComponent<BossWeapons>().SpearThrust();
                GetComponent<BossWeapons>().ShootDarts();
               
                break;
            case 8:
                GetComponent<BossWeapons>().SpearThrust();
                GetComponent<BossWeapons>().ShootDarts();
                GetComponent<BossWeapons>().GroundStomp();

                break;
               
                //    audioSrc.PlayOneShot(landOnFish);
                //    break;
        }
    }

  
    

}