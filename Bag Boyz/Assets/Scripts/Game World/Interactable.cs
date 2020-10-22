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
    private bool isEmpty;

    Behaviour halo;
    

    private void OnValidate()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            if (!isEmpty)
            {
                inventory.AddItem(item);
                isEmpty = true;
            }
        }

        if (isInRange)
        {
            if(!isEmpty)
            {
                halo.enabled = true;
            }
            else if (isEmpty)
            {
                halo.enabled = false;
            }
        }
        else if (isInRange == false)
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
