using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public PlayerController player;
    public DialogueTrigger speechTrigger;
    public Text speechText;

    [SerializeField] KeyCode interactKey = KeyCode.E;

    [System.Serializable]
    public enum TypeOfNPC
    {
        Employee1,
        Employee2,
        Employee3,
        Employee4,
    }

    public TypeOfNPC thisNPC;

    private GameObject[] speechObjects;

    private bool isInRange;
    private bool triggeredDialogue = false;
    private bool thisInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        speechObjects = GameObject.FindGameObjectsWithTag("Speech");

        HideSpeech();
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange && Input.GetKeyDown(interactKey))
        {

            if(!triggeredDialogue)
            {

                ShowSpeech();

                speechTrigger.TriggerDialogue();

                triggeredDialogue = true;
            }
            else
            {

                speechTrigger.DisplayNextSentence();

            }
            
        }
        
        if (!isInRange)
        {
            HideSpeech();
        }
    }

    public void DetermineDialogue(TypeOfNPC npcType)
    {
        int i = (int)npcType;

        switch (i)
        {
            case 0:
                
                break;
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }


    private void ShowSpeech()
    {
        foreach(GameObject speechObject in speechObjects)
        {
            speechObject.SetActive(true);
        }
    }

    private void HideSpeech()
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
