using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerAttack, playerHit, jumpSound, enemyAttack, enemyHit,
        enemySound, landOnFish, fishAttack, bubblePop, punctureWound, stompSound, thrust,
        dart, grunt1;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("throw");
        playerHit = Resources.Load<AudioClip>("damaged");
        jumpSound = Resources.Load<AudioClip>("jump");
        enemyAttack = Resources.Load<AudioClip>("slash");
        enemyHit = Resources.Load<AudioClip>("enemyDamaged");
        enemySound = Resources.Load<AudioClip>("enemyNoise");
        landOnFish = Resources.Load<AudioClip>("poisoned");
        fishAttack = Resources.Load<AudioClip>("fishShot");
        bubblePop = Resources.Load<AudioClip>("splash");
        punctureWound = Resources.Load<AudioClip>("puncture");
        stompSound = Resources.Load<AudioClip>("groundCrush");
        thrust = Resources.Load<AudioClip>("spearThrust");
        dart = Resources.Load<AudioClip>("dartShot");
        grunt1 = Resources.Load<AudioClip>("irritated");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "throw":
                audioSrc.PlayOneShot(playerAttack);
                break;
            case "damaged":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "slash":
                audioSrc.PlayOneShot(enemyAttack);
                break;
            case "enemyDamaged":
                audioSrc.PlayOneShot(enemyHit);
                break;
            case "enemyNoise":
                audioSrc.PlayOneShot(enemySound);
                break;
            case "poisoned":
                audioSrc.PlayOneShot(landOnFish);
                break;
            case "fishShot":
                audioSrc.PlayOneShot(fishAttack);
                break;
            case "splash":
                audioSrc.PlayOneShot(bubblePop);
                break;
            case "puncture":
                audioSrc.PlayOneShot(punctureWound);
                break;
            case "groundCrush":
                audioSrc.PlayOneShot(stompSound);
                break;
            case "spearThrust":
                audioSrc.PlayOneShot(thrust);
                break;
            case "dartShot":
                audioSrc.PlayOneShot(dart);
                break;
            case "irritated":
                audioSrc.PlayOneShot(grunt1);
                break;
        }
    }

}
