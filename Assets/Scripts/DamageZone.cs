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
        Debug.Log($"{other}������DamageZone��");
        Hero_boli = other.GetComponent<HeroAttribute>();
        if (Hero_boli == null)
        {
            return;
        }
        if (Hero_boli.ChangeHealth(Health_Damage) == true)
        {
            Debug.Log($"{other}�ܵ���{Health_Damage}���˺���");
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
            Debug.Log($"{other}վ��DamageZone�ϣ�");
            
            if (Hero_boli.ChangeHealth(Health_Damage) == true)
            {
                Debug.Log($"{other}�ܵ���{Health_Damage}���˺���");
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
