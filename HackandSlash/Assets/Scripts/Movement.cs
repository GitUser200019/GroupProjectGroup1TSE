using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    //set currentscene in build index so that it can be restated
    public int currentScene;

    Animator anim;

    [Header("Damage")]

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public GameObject deflect;

    [Header("Movement")]
    public float MoveSpeed;
    public float jumpForce;
    private float moveInput;
    public float dashSpeed;
    public float negDashSpeed;

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

    [SerializeField]
    //Scene scene;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        //SceneManager.GetActiveScene();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            anim.SetTrigger("Run");
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
            anim.SetTrigger("Run");
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
            anim.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        OutOfBounds();





        // faceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            DashAttack();
            anim.SetTrigger("Attack");
            swordslash.Play();
            swordslash.pitch = Random.Range(0.66f, 1);
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
        //par.transform.localScale = Scalerz;

    }



    void DashAttack()
    {
        GameObject.Instantiate(deflect,transform.position,transform.rotation);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }


        if (facingRight == true)
        {
            rb.AddForce(transform.right * dashSpeed);
            //transform.position += Vector3.right * MoveSpeed;
        }
        else
        {
            rb.AddForce(transform.right * negDashSpeed);
            //transform.position -= Vector3.right * MoveSpeed;
        }


    }

    void OutOfBounds()
    {
        if (transform.position.y < 0)
        {
            
            
                //SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
            
        }
    }

}
