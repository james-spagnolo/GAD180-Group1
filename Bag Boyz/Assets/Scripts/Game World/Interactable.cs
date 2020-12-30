using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public string itemName;

    [SerializeField] Item item;


    private KeyCode interactKey;

    private PlayerController player;
    private InventoryManager inventory;

    private bool isInRange;
    private bool isCollected;
    private bool thisInteract = false;

    private float interactionTimer;

    

    

    
    

    private void OnValidate()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
        //GetComponent<Halo>().enabled = false;
        //halo = GetComponent("Halo");
        //halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        //halo.enabled = false;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();

        interactionTimer = player.interactionTimer;

        itemName = item.name;

        interactKey = ControlsManager.CM.interact;
        
    }

    private void Update()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");

        if (isInRange && Input.GetKeyDown(interactKey))
        {
            if (!isCollected)
            {
                thisInteract = true;
            }
        }

        if (thisInteract)
        {
            if(interactionTimer > 0)
            {
                interactionTimer -= Time.deltaTime;
                player.collectingItem = true;
            }
            else
            {
                PickUpItem();
            }
        }

        if (isInRange)
        {
            if(!isCollected)
            {
                halo.enabled = true;
            }
            else if (isCollected)
            {
                halo.enabled = false;
            }
        }
        else
        {
            halo.enabled = false;
        }

    }

    private void PickUpItem()
    {
        thisInteract = false;
        player.collectingItem = false;
        inventory.AddItem(item);
        isCollected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //Debug.Log("Player now NOT in range");
        }
    }
}
