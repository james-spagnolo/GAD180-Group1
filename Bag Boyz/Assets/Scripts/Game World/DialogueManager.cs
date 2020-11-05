using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public PlayerController player;

    public Text nameText;
    public Text speechText;


    private Queue<string> sentences;
    private Queue<string> names;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }




    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation");

        player.canMove = false;
        //player.TurnOffAnimations();

        names.Clear();

        foreach(string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 || names.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        nameText.text = name;

        string sentence = sentences.Dequeue();
        speechText.text = sentence;
    }



    public void EndDialogue()
    {
        Debug.Log("End of Conversation");

        player.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
