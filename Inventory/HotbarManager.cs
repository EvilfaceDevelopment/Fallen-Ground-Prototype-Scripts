using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{

    public HotbarSlot[] HotbarSlots; //UI
    public Transform slotParent; //UI Slot Parent
    public GameObject[] HandObjects;
    //----------------------------------------------
    // Current 'selected' hotbar slot and corresponding hand object.
    public HotbarSlot CurrentSlot;

 
    public GameObject CurrentHandObject;
    // Hand Object Plugins
    public ItemPlugin[] Plugins;
    
    // Use this for initialization
    void Start()
    {
        HotbarSlots = slotParent.GetComponentsInChildren<HotbarSlot>();
        CurrentSlot = HotbarSlots[0];
    }

   

    void Update()
    {
        HotBarInputHandler(); //check to see if the current slot has been changed
        HotbarSlotUpdater(); 
        DisableAllObjectsExceptCurrent();
        UpdateHandObject();
    }

    public void DisableAllObjectsExceptCurrent()
    {
        foreach (GameObject go in HandObjects)
        {
            if (go.GetComponentInChildren<ObjectDefinition>().ItemId != CurrentSlot.CurrentInventoryItem.ItemId)
            {
                go.gameObject.SetActive(false);
            }
        }
    }

    public void HotbarSlotUpdater()
    {
        
        for (int i = 0; i < (HotbarSlots.Length -1); i++)
        {
            HotbarSlots[i].CurrentInventoryItem._currentItem = GameManager.Instance.InvManager.AllInventoryItems[i];
        }

    }


    public void DisableAllObjectsOnStart()
    {

        foreach (GameObject go in HandObjects)
        {
            go.gameObject.SetActive(false);
        }
    }

    public void UpdateHandObject()
    {
        if (!CurrentSlot) return;
        CurrentHandObject = GameManager.Instance.GetHandObjectById(CurrentSlot.CurrentInventoryItem.ItemId);
        if (CurrentHandObject)
        {
            CurrentHandObject.gameObject.SetActive(true);
            Plugins = CurrentHandObject.gameObject.GetComponentsInChildren<ItemPlugin>();
        }
    }

    public void UseCurrentObjectInHand(RaycastHit hit)
    {
        foreach (ItemPlugin p in Plugins)
        {
            p.Use(hit);
        }
    }

    void HotBarInputHandler()
    {


        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            CurrentSlot = HotbarSlots[0];
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            CurrentSlot = HotbarSlots[1];
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            CurrentSlot = HotbarSlots[2];
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        { 
            CurrentSlot = HotbarSlots[3];
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            CurrentSlot = HotbarSlots[4];
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            CurrentSlot = HotbarSlots[5];
        }

        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            CurrentSlot = HotbarSlots[6];
        }

        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
          
            CurrentSlot = HotbarSlots[7];
        }
        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            CurrentSlot = HotbarSlots[8];
        }
    }
}