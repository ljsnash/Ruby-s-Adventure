using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health_Damage = -100;
    public float Invincible = 3.0f;
    Timer timer;
    HeroAttribute Hero_boli;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other}碰到了DamageZone！");
        Hero_boli = other.GetComponent<HeroAttribute>();
        if (Hero_boli == null)
        {
            return;
        }
        if (Hero_boli.ChangeHealth(Health_Damage) == true)
        {
            Debug.Log($"{other}受到了{Health_Damage}点伤害！");
        }

        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(Invincible);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Hero_boli = other.GetComponent<HeroAttribute>();
        if (Hero_boli == null)
        {
            return;
        }
        if (timer.OnTimer() == true)
        {
            Debug.Log($"{other}站在DamageZone上！");
            
            if (Hero_boli.ChangeHealth(Health_Damage) == true)
            {
                Debug.Log($"{other}受到了{Health_Damage}点伤害！");
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (timer != null)
        {
            Destroy(timer);
        }
    }
}
