using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource menuMusic;


    private void Start()
    {
        //Play Main Menu Theme
        menuMusic.Play();
    }

    

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
