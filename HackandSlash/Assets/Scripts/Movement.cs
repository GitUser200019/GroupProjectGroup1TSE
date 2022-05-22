using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Damage")]
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    [Header("Movement")]
    public float MoveSpeed;
    public float jumpForce;
    private float moveInput;

    [Header("Components")]
    private Rigidbody2D rb;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public GameObject sword;
    public AudioSource swordslash;
    public ParticleSystem par;

    [Header("data variables")]
    bool Jump = false;
    bool facingRight = true;
    bool isGrounded;
    public int extraJumps;
    public int extraJumpsValue;

    Vector3 mousePosition = Input.mousePosition;
    
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);

        //sword.transform.up = mousePosition - transform.position;

        // faceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            DashAttack();
            swordslash.Play();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Vector3 Scalerz = transform.localScale;
        Scaler.x *= -1;
        Scalerz.z *= -1;
        transform.localScale = Scaler;
        par.transform.localScale = Scalerz;

    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
         mousePosition.y - transform.position.y
        );

        transform.right = direction;
    }

    void DashAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    

        if (facingRight == true)
        {
            //transform.position = Vector3.MoveTowards(mousePosition, mousePosition);
            transform.position += Vector3.right * MoveSpeed;
        }
        else
        {
            transform.position -= Vector3.right * MoveSpeed;
        }


    }

}
