using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    public float fMoveSpeed = 1.0f;
    Rigidbody2D rigidbody2d;
    public float Invincible = 2.5f;
    private bool bRight = true;
    private bool bRepaired = false;
    Timer timer;
    public ParticleSystem smokeEffect;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(Invincible);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetRepaired() == true)
        {
            return;
        }
        Vector2 position = transform.position;
        if (timer.OnTimer() == true)
        {
            bRight = !bRight;
        }
        if (bRight == true)
        {
            position.x = position.x + fMoveSpeed * Time.deltaTime;
        }
        else
        {
            position.x = position.x - fMoveSpeed * Time.deltaTime;
        }
           
        //position.y = position.y + fMoveSpeed *  Time.deltaTime;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GetRepaired())
        {
            return;
        }
        HeroAttribute Hero_boli = other.gameObject.GetComponent<HeroAttribute>();
        if (Hero_boli != null)
        {
            Hero_boli.ChangeHealth(-50);
            Debug.Log($"{Hero_boli.Name}±»Åöµ½ÁË£¡");
        }
    }

    public void SetRepaired(bool repair)
    {
        bRepaired = repair;
        rigidbody2d.simulated = !repair;
        if (repair == true)
        {
            //Destroy(smokeEffect);
            Debug.Log($"smokeEffect = {smokeEffect.name}");
            smokeEffect.Stop();
        }
    }

    public bool GetRepaired()
    {
        return bRepaired;
    }
}
