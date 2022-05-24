using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletProjectile : MonoBehaviour
{
    public float TravelSpeed;
    public GameObject friendbullet;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.position * TravelSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * TravelSpeed * Time.deltaTime);
        
         //GetComponent<Rigidbody2D>().AddForce(transform.right * TravelSpeed);
    
    }

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("test");
    if(collider.tag =="deflect"){
       Debug.Log("test");
        
        GameObject.Instantiate(friendbullet,transform.position,transform.rotation*Quaternion.Euler(0f,180f,0));
        Destroy(gameObject);
    }
    if(collider.tag =="wall"){
           Debug.Log("wall");
        Destroy(gameObject);
        }
    }

}
