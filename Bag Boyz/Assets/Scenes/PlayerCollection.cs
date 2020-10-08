using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private int itemsLeft = 5;
    bool nearItem = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("q"))
        {
            //Add grocery item
            //Change shelf
            if (nearItem)
            {
                itemsLeft -= 1;
                print("Items Left: " + itemsLeft);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Grocery")
        {
            nearItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grocery")
        {
            nearItem = false;
        }
    }
}
