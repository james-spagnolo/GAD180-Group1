using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public int sentences;
    public int names;

    private void Awake()
    {
        names = dialogue.names.Length;
        sentences = dialogue.sentences.Length;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void DisplayNextSentence()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
