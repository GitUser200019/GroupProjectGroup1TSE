using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumePanel : MonoBehaviour
{
    public GameObject volPan;

    // Start is called before the first frame update
    void Start()
    {

        volPan.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && volPan.activeInHierarchy == false)
        {
            volPan.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            volPan.SetActive(false);
        }
    }
}
