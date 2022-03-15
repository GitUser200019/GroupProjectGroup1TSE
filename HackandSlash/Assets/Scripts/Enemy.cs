using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    public float health = 100;
    public Text dmgText;

    private float dazedTime;
    public float startedDazedTime;

    public float speed;

    public GameObject player;
    //to damage player
    public int damage;

    public Image healthBar;

    [Header("Gun")]
    public GameObject gunFirePos;
    public GameObject bullet;
    public float fireTimer = 0;
    public float canShoot = 0.56f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

       // transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(distance < 7)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > canShoot)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                fireTimer = 0;
            }
        }
        




    }
    public void TakeDamage(int damage)
    {
        dazedTime = startedDazedTime;

        anim.SetTrigger("dmgT");
        health -= damage;
        Debug.Log("Took " + damage + " damage");
        dmgText.text = damage.ToString();
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
