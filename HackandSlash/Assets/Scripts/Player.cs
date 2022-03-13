using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int MaxHealth = 250;
    float CurrHealth;

    int MaxStamina = 250;
    float CurrStamina;

    public Image hpBar;
    public Image sBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrHealth = MaxHealth;
        CurrStamina = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = CurrHealth / 100f;
        sBar.fillAmount = CurrStamina / 100f;
    }

    
}
