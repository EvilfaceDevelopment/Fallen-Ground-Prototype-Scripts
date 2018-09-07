using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Inventory.Slots;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotHolder : MonoBehaviour
{
    public InventoryItemSlot CurrentInventoryItem;
    public GameObject Highlight;
    
 
public void Awake()
    {
        CurrentInventoryItem = transform.GetComponentInChildren<InventoryItemSlot>();
        if (CurrentInventoryItem == null)
        {
            Debug.Log("Slot has no Inventory Item as a child");
        }
    }
  
}
