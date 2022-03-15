using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
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
        transform.Translate(Vector2.left * TravelSpeed * Time.deltaTime);
    }
}
