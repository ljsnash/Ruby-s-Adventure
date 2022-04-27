using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttribute : Attribute
{
    private bool IsTalk = false;
    AudioSource audioSource;
    public AudioClip audioHit;
    // Start is called before the first frame update
    void Start()
    {
        ChangeHealth(Health_Max - 200);
        //GetCurrentHealth();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeHealth(-50);
    }

    public void SetTalkState(bool isTalk)
    {
        IsTalk = isTalk;
    }

    public bool GetTalkState()
    {
        return IsTalk;
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(audioHit);
    }

    public bool GetDamage(int Damage)
    {
        bool bDamage = ChangeHealth(-Damage);
        if(bDamage == true)
        {
            PlayHitSound();
        }
        return bDamage;
    }
}
