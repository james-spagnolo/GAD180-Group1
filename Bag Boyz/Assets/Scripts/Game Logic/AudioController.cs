using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource gameMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseAudio()
    {
        gameMusic.Pause();
    }

    public void ResumeAudio()
    {
        gameMusic.Play();
    }
}
