using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*   This class is a holder for the player's health to be represented on the screen
*/
public class barHealth : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;
    //Start is called before the first frame update
    void Start()
    {
        totalhealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
