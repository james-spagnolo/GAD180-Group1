using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkout : MonoBehaviour
{

    public string[] dialogue;
    public string[] npcName;

    public GameLogic gameLogic;
    public DialogueTrigger speechTrigger;
    public Text speechText;

    private GameObject thisCheckout;
    private PlayerController player;

    [SerializeField] KeyCode interactKey = KeyCode.E;

    public GameObject[] speechObjects;

    private bool isInRange;
    private bool triggeredDialogue = false;
    private bool thisInteract = false;

    private int sentencesLeft;


    private void Awake()
    {
        speechObjects = GameObject.FindGameObjectsWithTag("Speech");
        sentencesLeft = speechTrigger.sentences;

        thisCheckout = this.gameObject;

        //thisCheckout.transform.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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

            sentencesLeft -= 1;

            //DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);

            triggeredDialogue = true;

            player.Move(0, 0);
            player.npcInteract();
        }

        else if (isInRange && triggeredDialogue)
        {
            player.npcInteract();

            if (Input.GetKeyDown(interactKey))
            {
                speechTrigger.DisplayNextSentence();

                if (sentencesLeft > 0)
                {
                    sentencesLeft -= 1;
                }
                else if (sentencesLeft <= 0)
                {
                    gameLogic.WinScreen();
                }
            }
        }

        else if (!isInRange && triggeredDialogue)
        {
            HideSpeech();

            triggeredDialogue = false;
        }
    }

    private void ShowSpeech()
    {
        foreach (GameObject speechObject in speechObjects)
        {
            speechObject.SetActive(true);
        }
    }

    public void HideSpeech()
    {
        foreach (GameObject speechObject in speechObjects)
        {
            speechObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Entered NPC Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Left NPC Range");
        }
    }
}
