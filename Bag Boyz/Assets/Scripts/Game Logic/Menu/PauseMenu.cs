using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private KeyCode pauseKey;

    private GameObject[] pauseObjects;
    private GameObject[] gameUI;

    private AudioController gameAudio;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameUI = GameObject.FindGameObjectsWithTag("GameUI");

        gameAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        pauseKey = KeyCode.Escape;
        
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(pauseKey))
        {
            /*
            if (Time.timeScale == 1)
            {
                
                ShowPaused();
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                HidePaused();
                Time.timeScale = 1;
                
            }
            */

            PauseControl();
        }
    }

    //Reloads the level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();

            gameAudio.PauseAudio();
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();

            gameAudio.ResumeAudio();
        }
    }


    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in gameUI)
        {
            g.SetActive(false);
        }
    }


    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in gameUI)
        {
            g.SetActive(true);
        }
    }


    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }


}
