using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    public float Invincible = 3.0f;
    Timer timer;
    HeroAttribute Hero_boli;
    [Range(0, 10000)]
    public int Damage;
    private DamageZone()
    {
        GameMath.SetNumberMin0(Damage);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other}������DamageZone��");
        Hero_boli = other.GetComponent<HeroAttribute>();
        if (Hero_boli == null)
        {
            return;
        }
        if (Hero_boli.GetDamage(Damage) == true)
        {
            Debug.Log($"{other}�ܵ���{Damage}���˺���");
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
            
            if (Hero_boli.GetDamage(Damage) == true)
            {
                Debug.Log($"{other}�ܵ���{Damage}���˺���");
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
