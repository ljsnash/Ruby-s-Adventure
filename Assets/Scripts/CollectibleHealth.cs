using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    public int Health_Revert = 100;
    public AudioClip collectionedClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other}Åöµ½ÁË£¡");
        HeroAttribute Hero_boli = other.GetComponent<HeroAttribute>();
        if (Hero_boli == null)
        {
            return;
        }
        if (Hero_boli.ChangeHealth(Health_Revert) == true)
        {
            Hero_boli.PlaySound(collectionedClip);
            Destroy(gameObject);
        }
    }

   
}
