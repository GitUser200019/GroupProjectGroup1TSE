using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletProjectile : MonoBehaviour
{
    public float TravelSpeed;
    public GameObject friendbullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.position * TravelSpeed * Time.deltaTime;
        transform.Translate(Vector2.left * TravelSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider){
    if(collider.tag =="Deflect"){
       Debug.Log("test");
        
        GameObject.Instantiate(friendbullet,transform.position,transform.rotation*Quaternion.Euler(0f,180f,0));
        Destroy(gameObject);
    }
       if(collider.tag =="Wall"){
        Destroy(gameObject);
        }
    }

}
