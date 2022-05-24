using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendbullet : MonoBehaviour
{
    public float TravelSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.position * TravelSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * TravelSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag =="Enemy"){
            collider.gameObject.GetComponent<Enemy>().TakeDamage(200);
        }
        if(collider.tag =="wall"){
        Destroy(gameObject);
        }
    }

}
