using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePoint;

    // Start is called before the first frame update
    public void StompAttack()
    {

        Instantiate(projectile, firePoint.position, firePoint.rotation);

    }


}
