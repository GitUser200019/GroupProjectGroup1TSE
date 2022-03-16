using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private int timer;
    public float timetildestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer+=1;
        if(timer >= timetildestroy){
            Destroy(this.gameObject);
        }
    }
}
