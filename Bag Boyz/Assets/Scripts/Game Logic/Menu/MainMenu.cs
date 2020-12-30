using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource menuMusic;

    private GameObject[] options;
    private GameObject[] instructions;
    private GameObject[] controls;


    private void Start()
    {
        //Play Main Menu Theme
        menuMusic.Play();

        options = GameObject.FindGameObjectsWithTag("Options");
        instructions = GameObject.FindGameObjectsWithTag("HowToPlay");
        controls = GameObject.FindGameObjectsWithTag("Controls");

        HideOptions();
        HideInstructions();
        HideControls();
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

    public void DisplayInstructions()
    {
        foreach (GameObject g in instructions)
        {
            g.SetActive(true);
        }
    }

    public void HideInstructions()
    {
        foreach (GameObject g in instructions)
        {
            g.SetActive(false);
        }
    }


    public void DisplayControls()
    {
        HideInstructions();
        HideOptions();

        foreach (GameObject g in controls)
        {
            g.SetActive(true);
        }
    }


    public void HideControls()
    {
        
        foreach (GameObject g in controls)
        {
            g.SetActive(false);
        }
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
