using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public int MaxHealth = 150;
    public float CurrHealth;

    

    Scene scene;
   

    // Start is called before the first frame update
    void Start()
    {
        CurrHealth = MaxHealth;
       
        
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrHealth < 0)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        //hpBar.fillAmount = CurrHealth / 100f;
        //sBar.fillAmount = CurrStamina / 100f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            CurrHealth -= 40;
            Debug.Log("Enemyhit player");
            
        }
    }

    public void RestartLevel()
    {
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
