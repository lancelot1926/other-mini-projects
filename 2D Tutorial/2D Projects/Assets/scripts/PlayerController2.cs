using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float MoveSpeed;
    public float AttackTime;
    public string StartPoint;

    private Rigidbody2D RigBody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private static bool playerExists;
    private bool attacking;
    private float attackTimeCounter;

    private void Start()
    {
        anim = GetComponent<Animator>();
        RigBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.J))
        {
            attackTimeCounter = AttackTime;
            attacking = true;
            RigBody.velocity = Vector2.zero;
            anim.SetBool("Attack", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
    }

    void FixedUpdate()
    {
        playerMoving = false;

        if (horizontalMove > 0.5f || horizontalMove < -0.5f) 
        {
            //transform.Translate(new Vector3(horizontalMove * MoveSpeed * Time.fixedDeltaTime,0f,0f));
            RigBody.velocity = new Vector2(horizontalMove * MoveSpeed, RigBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(horizontalMove, 0f);
        }

        if (verticalMove > 0.5f || verticalMove < -0.5)
        {
            //transform.Translate(new Vector3(0f, verticalMove * MoveSpeed * Time.fixedDeltaTime, 0f));
            RigBody.velocity = new Vector2(RigBody.velocity.x, verticalMove * MoveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, verticalMove);
        }

        if (horizontalMove < 0.5f && horizontalMove > -0.5f)
        {
            RigBody.velocity = new Vector2(0f, RigBody.velocity.y);
        }
        if (verticalMove < 0.5f && verticalMove > -0.5f)
        {
            RigBody.velocity = new Vector2(RigBody.velocity.x, 0f);
        }

        

        anim.SetFloat("MoveX", horizontalMove);
        anim.SetFloat("MoveY", verticalMove);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        anim.SetBool("PlayerMoving", playerMoving);
    }
}
