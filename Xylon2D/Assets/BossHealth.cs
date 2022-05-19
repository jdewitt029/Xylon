using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int damage)
    {

        health -= damage;

       
    }

  

    public int getHealth()
    {
        return health;
        //Debug.Log(health);
    }
}
