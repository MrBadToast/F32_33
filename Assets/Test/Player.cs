using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private Vector2 moveDirection;
    private bool grounded;
    private bool jump;
    private float jumpTime = 0;

    public float speed = 5;
    public float power = 5;

    [HideInInspector]
    public bool canMove = false;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        //이동
        Move(Input.GetAxisRaw("Horizontal") * speed);

        //땅위인지 체크
        grounded = GroundCheck();

        //점프
        Jump(power);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Move(float speed)
    {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    private bool GroundCheck()
    {
        if(rigidbody2D.velocity.y <= 0.000001f)
        {
            Vector2 center = (Vector2)transform.position + (Vector2)boxCollider2D.offset + new Vector2(0,-0.1f);
            RaycastHit2D hit = Physics2D.BoxCast(center, boxCollider2D.size, 0, Vector2.zero, 0, 1 << LayerMask.NameToLayer("Ground"));
            return hit;
        }
        return false;
    }

    private void Jump(float power)
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(Vector2.up * power);

        //점프 끊기
        if (Input.GetKeyUp(KeyCode.Space) && rigidbody2D.velocity.y > 0)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
    }

}
