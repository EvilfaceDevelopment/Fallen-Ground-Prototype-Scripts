using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory.Slots;
using UnityEngine;

public class HotbarSlot : MonoBehaviour
{
    public InventoryItemSlot CurrentInventoryItem;
    // initialization
    public void Awake()
    {
        CurrentInventoryItem = transform.GetComponentInChildren<InventoryItemSlot>();
        if (CurrentInventoryItem == null)
        {
            Debug.Log("Slot has no Inventory Item as a child");
        }
    }
}

