﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
    [SerializeField] GameLogic gameLogic;

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (isFull())
            return false;

        items.Add(item);
        gameLogic.CollectedItem(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool isFull()
    {
        return items.Count >= itemSlots.Length;
    }

}
