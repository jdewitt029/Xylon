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

    public Transform firePoint1;

    public Transform firePoint2;

    public Transform firePoint3;

    public GameObject bullets, rocks, spearSlash;

    public BossWeapons attackChoice;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        BossWeapons attackChoice = GetComponent<BossWeapons>();
    }

    // Update is called once per frame
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
        //rand = Random.Range(1, 3);
        rand = 1;
        Debug.Log(rand);
        Attacks(rand);
       
    }

    public void TakeDamage(int damage)
    {

        SoundManager.PlaySound("enemyDamaged");
        health -= damage;

        //animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            //dead = true;

            //animator.SetBool("dead", true);

            Die();

        }
    }

    void Die()
    {

        //animator.SetTrigger("death");

        //GetComponent<Boss>().enabled = false;

        //boxCollide.GetComponent<BoxCollider2D>().enabled = false;
        //PolyCollide.GetComponent<PolygonCollider2D>().enabled = false;

        Destroy(gameObject);

    }

    private void Attacks(int r)
    {
        Debug.Log(r);
        switch (r)
        {

            case 1:
                //animator.SetTrigger("spear");
                ShootDarts();
                break;
            case 2:
                //animator.SetTrigger("darts");
                SpearThrust();
                break;
            case 3:
                GroundStomp();
                //animator.SetTrigger("stomp");
                break;
            //case 4:
            //    animator.SetTrigger("darts");
            //    break;
            //case 5:
            //    audioSrc.PlayOneShot(jumpSound);
            //    break;
            //case 6:
            //    audioSrc.PlayOneShot(enemyAttack);
            //    break;
            //case 7:
            //    audioSrc.PlayOneShot(enemyHit);
            //    break;
            //case 8:
            //    audioSrc.PlayOneShot(enemySound);
            //    break;
            //case 9:
            //    audioSrc.PlayOneShot(landOnFish);
            //    break;
        }
    }

    void ShootDarts()
    {

        Instantiate(bullets, firePoint1.position, firePoint1.rotation);
        //SoundManager.PlaySound("throw");
        animator.SetTrigger("darts");


    }

    void SpearThrust()
    {

        Instantiate(spearSlash, firePoint2.position, firePoint2.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("spear");


    }


    void GroundStomp()
    {

        Instantiate(rocks, firePoint2.position, firePoint2.rotation);
        SoundManager.PlaySound("throw");
        animator.SetTrigger("stomp");


    }

}