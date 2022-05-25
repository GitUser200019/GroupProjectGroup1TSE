using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlPanel;

    void Start()
    {
        controlPanel.SetActive(false);   
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void controlButton()
    {
        controlPanel.SetActive(true);
    }

    public void closeCTRLpan()
    {
        controlPanel.SetActive(false);
    }


    public void QuitButton()
    {
        Application.Quit();
    }
}
