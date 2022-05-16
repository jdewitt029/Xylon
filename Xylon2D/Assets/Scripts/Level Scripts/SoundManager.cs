using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerAttack, playerHit, jumpSound, enemyAttack, enemyHit,
        enemySound, landOnFish;

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
        }
    }

}
