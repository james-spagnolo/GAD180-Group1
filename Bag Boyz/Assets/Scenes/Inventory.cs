using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<GroceryItem> itemsList;

    public Inventory()
    {
        itemsList = new List<GroceryItem>();

        Debug.Log("Inventory");
    }


    public void AddItem(GroceryItem item)
    {
        itemsList.Add(item);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
