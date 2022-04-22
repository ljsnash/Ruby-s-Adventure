using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControl : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    MoveController movecontroller;
    HeroAttribute Hero_boli;
    NonPlayerCharacter dialogNPC;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Hero_boli = gameObject.GetComponent<HeroAttribute>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            movecontroller = gameObject.GetComponent<MoveController>();
            RaycastHit2D hit = Hit(rigidbody2d.position + Vector2.up * 0.05f, movecontroller.GetLookDirection(), 1.5f, "NPC");
            if (hit.collider != null)
            {
                dialogNPC = hit.collider.gameObject.GetComponent<NonPlayerCharacter>();
                dialogNPC.ChangeDialogBox(Hero_boli);
                Debug.Log($"…‰œﬂª˜÷–¡À{hit.collider.gameObject}");
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space))&& (Hero_boli.GetTalkState() == true))
        {
            dialogNPC.ChangePage();
        }
    }

    public RaycastHit2D Hit(Vector2 Position, Vector2 Direction, float Distance, string Layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(Position, Direction, Distance, LayerMask.GetMask(Layer));
        return hit;
    }
}
