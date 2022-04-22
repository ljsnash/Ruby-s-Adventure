using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CogBullet;
    public float BulletForce;
    Rigidbody2D rigidbody2d;
    HeroAttribute Hero_boli;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Hero_boli = gameObject.GetComponent<HeroAttribute>();
    }

    private void Update()
    {
        if(!Hero_boli.GetTalkState()&& (Input.GetKeyDown(KeyCode.Space)))
        {
            Launch();
        }
    }
    void Launch()
    {
        GameObject CogBulletObject = Instantiate(CogBullet, rigidbody2d.position,Quaternion.identity);
        CogBullet cogBullet = CogBulletObject.GetComponent<CogBullet>();
        MoveController moveController = gameObject.GetComponent<MoveController>();
        Vector2 LookDirection = moveController.GetLookDirection();
        cogBullet.Launch(LookDirection, BulletForce);
    }
}
