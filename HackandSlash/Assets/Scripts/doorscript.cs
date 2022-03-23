using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    public GameObject interactText;
    public GameObject player;

    [Header("door")]
    public GameObject door;
    bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);


        if (distance < 2)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactText.SetActive(false);
                door.SetActive(false);
            }
        }
        
    }

    


}
