using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public string[] dialogue;
    public string[] npcName;

    public PlayerController player;
    public DialogueTrigger speechTrigger;
    public Text speechText;

    [SerializeField] KeyCode interactKey = KeyCode.E;

    /*
    [System.Serializable]
    public enum TypeOfNPC
    {
        Employee1,
        Employee2,
        Employee3,
        Employee4,
    }

    public TypeOfNPC thisNPC;
    */

    public GameObject[] speechObjects;

    private bool isInRange;
    private bool triggeredDialogue = false;
    private bool thisInteract = false;


    private void Awake()
    {
        speechObjects = GameObject.FindGameObjectsWithTag("Speech");
    }
    // Start is called before the first frame update
    void Start()
    {
       
        HideSpeech();
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange && !triggeredDialogue)
        {
            ShowSpeech();

            speechTrigger.TriggerDialogue();

            //DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);

            triggeredDialogue = true;

            player.Move(0, 0);
        }

        else if (isInRange && triggeredDialogue)
        {
            if (Input.GetKeyDown(interactKey))
            {
                speechTrigger.DisplayNextSentence();
            }
        }

        else if (!isInRange && triggeredDialogue)
        {
            HideSpeech();

            triggeredDialogue = false;
        }

        /*
        if (isInRange && Input.GetKeyDown(interactKey))
        {

            if(!triggeredDialogue)
            {

                
            }
            else
            {

                speechTrigger.DisplayNextSentence();

                //DialogueSystem.Instance.ContinueDialogue();
            }
            
        }
        */


    }

    /*
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue);
    }
    */

    private void ShowSpeech()
    {
        foreach(GameObject speechObject in speechObjects)
        {
            speechObject.SetActive(true);
        }
    }

    public void HideSpeech()
    {
        foreach(GameObject speechObject in speechObjects)
        {
            speechObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Entered NPC Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Left NPC Range");
        }
    }
}
