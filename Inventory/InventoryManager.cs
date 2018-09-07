using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{


    //create player inventory with logic
    private static int _invSlotCount = 27;
    // ReSharper disable once InconsistentNaming
  
    public List<InventoryItem> AllInventoryItems;
    public InventoryItem TempinvItem;

  

    void Start()
    {

        for (int i = 0; i < _invSlotCount - 1; i++)
        {
            AllInventoryItems.Add(new InventoryItem(1)); //set the default item (empty object)
            InventoryItem tempitem;
            tempitem = GameManager.Instance.GetInventoryItemById(AllInventoryItems[i].ItemId);
            if (tempitem != null)
            {
                AllInventoryItems[i].CurrentItemStack = tempitem.CurrentItemStack;
                AllInventoryItems[i].ItemMaxStack = tempitem.ItemMaxStack;
                AllInventoryItems[i].ItemName = tempitem.ItemName;
                AllInventoryItems[i].ItemSprite = tempitem.ItemSprite;
            }
        }
    }

    public int GetCurrentAmountOfItemByID(int id)
    {
        int tempcounter = 0;
        for (int i = 0; i < AllInventoryItems.Count - 1; i++)
        {
            if (AllInventoryItems[i].ItemId == id)
            {
                tempcounter += AllInventoryItems[i].CurrentItemStack;
            }
        }

        return tempcounter;
    }

    public void AddItemToInventoryByInvItem(InventoryItem WOItem)
    {
        bool Added = false;
        for (int i = 0; i < AllInventoryItems.Count - 1; ++i)
        {
            if (!Added)
            {
                if (AllInventoryItems[i].ItemId == WOItem.ItemId) //if prexisting stack has enough room
                {
                    if ((AllInventoryItems[i].CurrentItemStack + WOItem.CurrentItemStack) <= AllInventoryItems[i].ItemMaxStack)
                    {
                        AllInventoryItems[i].CurrentItemStack += WOItem.CurrentItemStack;
                        Added = true;
                    }
                }

                if (AllInventoryItems[i].ItemId == 1) //if we hit an empty item
                {
                    
                    AllInventoryItems[i] = WOItem;
                    Added = true;
                }

            }
        }
    }

    public void AddItemToInventoryById(int id, int amount)
    {
        bool Added = false;
        for (int i = 0; i < AllInventoryItems.Count - 1; ++i)
        {
            if (!Added)
            {
                if (AllInventoryItems[i].ItemId == id) //if prexisting stack has enough room
                {
                    if ((AllInventoryItems[i].CurrentItemStack + amount) <= AllInventoryItems[i].ItemMaxStack)
                    {
                        AllInventoryItems[i].CurrentItemStack += amount;
                        Added = true;
                    }
                }

                if (AllInventoryItems[i].ItemId == 1) //if we hit an empty item
                {
                    InventoryItem temp = GameManager.Instance.GetInventoryItemById(id);
                    temp.CurrentItemStack = amount;
                    AllInventoryItems[i] = temp;
                    Added = true;
                }

            }
        }
    }

    public void RemoveItemFromInventoryById(int id, int amount)
    {
        bool removed = false;
        for (int i = 0; i < AllInventoryItems.Count - 1; ++i)
        {
            if (!removed)
            {
                if (AllInventoryItems[i].ItemId == id) //if prexisting stack 
                {
                    if ((AllInventoryItems[i].CurrentItemStack - amount) >= 0)
                    {
                        AllInventoryItems[i].CurrentItemStack -= amount;
                        removed = true;
                    }
                }
            }
        }
    }


    
    void Update()
    {
        for (int i = 0; i < AllInventoryItems.Count; i++)
        {
            if (AllInventoryItems[i].ItemId != 1 && AllInventoryItems[i].CurrentItemStack == 0)
            {
                AllInventoryItems[i] = GameManager.Instance.GetInventoryItemById(1);
            }
        }
    }
}
