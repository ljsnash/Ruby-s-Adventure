using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogBullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public AudioClip collectionedClip;
    //public string Name = "bullet";
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Launch(Vector2 direction,float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"×Óµ¯Åö×²µ½ÁË:{collision.gameObject}");
        EnemyMoveController Pida = collision.gameObject.GetComponent<EnemyMoveController>();
        if (Pida != null)
        {
            Pida.SetRepaired(true);
        }
        Destroy(gameObject);
    }

    public void PlayThrowSound(HeroAttribute Hero_boli)
    {
        if (Hero_boli == null)
        {
            return;
        }
        else
        {
            Hero_boli.PlaySound(collectionedClip);
        }
    }
}
