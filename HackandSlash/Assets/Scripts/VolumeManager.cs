using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance;

    [SerializeField] private AudioSource _music;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //volume  = 0 / mute sound
        if(Input.GetKeyDown(KeyCode.O))
        {
            ChangeMasterVolume(0);
        }
        //volume = 0.358 / unmute to max sound volume
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeMasterVolume(0.358f);
        }

        
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
    
}
