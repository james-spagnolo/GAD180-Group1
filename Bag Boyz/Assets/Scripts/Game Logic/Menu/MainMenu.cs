using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource menuMusic;

    public GameObject[] options;


    private void Start()
    {
        //Play Main Menu Theme
        menuMusic.Play();

        options = GameObject.FindGameObjectsWithTag("Options");

        HideOptions();
    }

    

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }


    public void DisplayOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(true);
        }
    }


    public void HideOptions()
    {
        foreach (GameObject g in options)
        {
            g.SetActive(false);
        }
    }
}
