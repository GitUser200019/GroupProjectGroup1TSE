using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    LevelObjectives lo;

    public Animator anim;

    public float health = 100;
    public Text dmgText;

    public GameObject enemyReloadPosition;
    public float enemyReloadTimer;
    public float enemyShootTimer;

    private float dazedTime;
    public float startedDazedTime;

    public float speed;

    public GameObject player;
    public GameObject gm;
    //to damage player
    public int damage;

    public Image healthBar;

    public GameObject deathslash;
    public GameObject deathparticle;
    public GameObject lowerhalf;
    public GameObject upperhalf;
    public GameObject fronthalf;
    public GameObject backhalf;
    public int shotgunner = 0;

    [Header("Gun")]
    public GameObject gunFirePos;
    public GameObject shotbar1;
    public GameObject shotbar2;
    public GameObject shotbar3;
    public GameObject bullet;
    public float fireTimer = 0;
    public float canShoot = 0.56f;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager");
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        lo = gm.GetComponent<LevelObjectives>();

        
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (dazedTime <= 0)
        { speed = 2; }
        else
        { speed = 0;
            dazedTime -= Time.deltaTime;
        }
        healthBar.fillAmount = health / 100f;

        //transform.Translate(Vector2.left * speed * Time.deltaTime);


    if(shotgunner == 0){
        if(distance < 18)
        {
            enemyShootTimer += Time.deltaTime;
            if (enemyShootTimer < 8)
            {


                fireTimer += Time.deltaTime;
                if (fireTimer > canShoot)
                {
                    
                    Instantiate(bullet, gunFirePos.transform.position, gunFirePos.transform.rotation);
                    fireTimer = 0;
                }
            }
            else if(enemyShootTimer > 10)
            {
                //move enemy towards reload pos
            }

        }
    }
    if(shotgunner == 1){
        if(distance < 18)
        {
            enemyShootTimer += Time.deltaTime;
            if (enemyShootTimer < 8)
            {


                fireTimer += Time.deltaTime;
                if (fireTimer > canShoot)
                {
                    
                    Instantiate(bullet, gunFirePos.transform.position, gunFirePos.transform.rotation);
                    Instantiate(bullet, shotbar1.transform.position,shotbar1.transform.rotation);
                    Instantiate(bullet, shotbar2.transform.position,shotbar2.transform.rotation);
                    Instantiate(bullet, shotbar3.transform.position,shotbar3.transform.rotation);
                   
                    fireTimer = 0;
                }
            }
            else if(enemyShootTimer > 10)
            {
                //move enemy towards reload pos
            }

        }
    }
        




    }
    public void TakeDamage(int damage)
    {
        dazedTime = startedDazedTime;

       // anim.SetTrigger("dmgT");
        health -= damage;
        Debug.Log("Took " + damage + " damage");
        //dmgText.text = damage.ToString();
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if(shotgunner == 0){
        Instantiate(deathslash,transform.position,transform.rotation);
        Instantiate(deathparticle,transform.position,transform.rotation);
        Instantiate(lowerhalf,transform.position,transform.rotation);
        Instantiate(upperhalf,transform.position,transform.rotation);
        Destroy(gameObject);
        lo.EnemiesInLevel--;
        }
        if(shotgunner == 1){
        Instantiate(deathslash,transform.position,transform.rotation);
        Instantiate(deathparticle,transform.position,transform.rotation);
        Instantiate(fronthalf,transform.position,transform.rotation);
        Instantiate(backhalf,transform.position,transform.rotation);
        Destroy(gameObject);
        lo.EnemiesInLevel--;
        }

    }
}
