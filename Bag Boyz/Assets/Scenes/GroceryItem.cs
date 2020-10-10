using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryItem : MonoBehaviour
{

    public enum ItemType
    {
        Apple,
        Bread,
        Carrot,
        Chicken,
        Grape,
        Lemon,
        Pineapple,
        Strawberry,
        Watermelon
    }

    public ItemType itemType;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
