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

    public GameObject player;

    public float speed;

    //to damage player
    public int damage;

    public Image healthBar;

    Vector3 distance;

    bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position - transform.position;
       // if (distance <  )
      //  {
       //     isInRange = true;
      //  }


        if (dazedTime <= 0)
        { speed = 2; }
        else
        { speed = 0;
            dazedTime -= Time.deltaTime;
        }
        healthBar.fillAmount = health / 100f;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
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
