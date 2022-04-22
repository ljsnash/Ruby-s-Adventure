using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour

{
    float horizontal;
    float vertical;
    public float moveunit = 0.1f;
    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, 0);
    Vector2 moveDirection = new Vector2(0, 0);
    bool IsMove;
    bool IsBack;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

       
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        moveDirection = new Vector2(horizontal, vertical);
        
        Vector2 newposition = new Vector2(position.x + moveunit * horizontal * Time.deltaTime, position.y + moveunit * vertical * Time.deltaTime);
        //Debug.Log($"Mathf.Approximately(position.x, newposition.x) = {Mathf.Approximately(position.x, newposition.x)}");
        //Debug.Log($"Mathf.Approximately(position.y, newposition.y) = {Mathf.Approximately(position.y, newposition.y)}");
        if (Mathf.Approximately(position.x, newposition.x)&& Mathf.Approximately(position.y, newposition.y))
        {           
            IsMove = false;
        }
        else
        {
            IsMove = true;
            lookDirection.Set(moveDirection.x, moveDirection.y);
            lookDirection.Normalize();
            if (newposition.y > position.y)
            {
                IsBack = true;
            }
            else
            {
                IsBack = false;
            }
        }
        //position.x = position.x + moveunit * horizontal * Time.deltaTime;
        //position.y = position.y + moveunit * vertical * Time.deltaTime;
        transform.position = newposition;
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetBool("IsMove", IsMove);
        animator.SetBool("IsBack", IsBack);
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

   
}
