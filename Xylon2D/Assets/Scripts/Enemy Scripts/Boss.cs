using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public float rayDistance = 1f;
    public Animator animator;
    int rand;

   

    //public int health = 100;

    [SerializeField] private PolygonCollider2D PolyCollide;
    [SerializeField] private BoxCollider2D boxCollide;
    [SerializeField] private float attackCooldown;

    private float cooldownTimer = Mathf.Infinity;

    private bool movingRight = true;

    public Transform groundDetection;

    public  BossHealth instance;
    //public static Boss instance;
    //public int healthCheck;
    void Start()
    {
      

    animator = GetComponent<Animator>();

    }

    private void Update()
    {
        //instance.getHealth();

        //Debug.Log(health);
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
        if (instance.getHealth() > 750)
        {
            attackCooldown = 2;
            rand = Random.Range(1, 4);
            //Debug.Log(rand);
            speed = 4;
            Attacks(rand);
        }
        else if (instance.getHealth() > 500 && instance.getHealth() <= 750)
        {

            attackCooldown = 2;
            rand = Random.Range(1, 8);
            speed = 7;
            //rand = 4;
            //Debug.Log(rand);
            Attacks(rand);

        }
        else if (instance.getHealth() > 250 && instance.getHealth() <= 500)
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

        instance.UpdateHealth(damage);
        //Debug.Log(instance.getHealth());

        if (instance.getHealth() <= 0)
        {
           
            Die();
        }
    }

    void Die()
    {

        //GetComponent<Boss>().speed = 0f;
        Destroy(gameObject);


    }

    private void Attacks(int r)
    {
        //Debug.Log(r);
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

  
    //public int getHealth()
    //{
    //    return health;
    //}

}