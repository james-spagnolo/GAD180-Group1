using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    
    private bool isInRange;
    private bool isCollected;

    //Component halo;
    

    private void OnValidate()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
        //GetComponent<Halo>().enabled = false;
        //halo = GetComponent("Halo");
        //halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        //halo.enabled = false;
    }

    private void Update()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");

        if (isInRange && Input.GetKeyDown(interactKey))
        {
            if (!isCollected)
            {
                inventory.AddItem(item);
                isCollected = true;
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
