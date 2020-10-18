using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    
    private bool isInRange;
    private bool isEmpty;

    private void Awake()
    {
        
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now NOT in range");
        }
    }
}
