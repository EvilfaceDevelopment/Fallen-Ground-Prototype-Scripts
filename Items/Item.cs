using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

[Serializable]
    public class InventoryItem
    {
        public int ParentContainerId;
        public int ItemId = 0;
        public int ItemMaxStack = 1;
        public int CurrentItemStack = 0;
        public Sprite ItemSprite;
        public String ItemName;
        


        public InventoryItem()
        {
           
        }

    public InventoryItem(int id)
        {
            ItemId = id;
        }
    }

[Serializable]
public class RequiredItem
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _RequiredAmountForSingleUnit;
    [SerializeField] private int _itemId;

    public int  ItemID
    {
        get
        {
            return _itemId;
        }
    
    }

    public string ItemName
    {
        get { return _itemName; }
    }

    public int AmountRequired
    {
        get { return _RequiredAmountForSingleUnit; }
    }
}

[Serializable]
    public class ItemData
    {
        [SerializeField] private ItemType type;
        [SerializeField] private string m_itemName;
        [SerializeField] private int m_itemId; //ID of the Item
        [SerializeField] [Range(1, 200)] private int m_itemMaxStack; //Maximum Stack size
        [SerializeField] private Sprite m_itemSprite; //Sprite for UI
        [SerializeField] private GameObject m_itemPrefab; //Prefab for instantiation
        [SerializeField] private RequiredItem[] _itemsRequiredForCrafting;
        [SerializeField] private InventoryItem _invItem;

        public RequiredItem[] ItemsRequiredForCrafting
        {
            get { return _itemsRequiredForCrafting; }
            set { _itemsRequiredForCrafting = value; }
        }

        public ItemType Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ItemId
        {
            get { return m_itemId; }
        }

    public InventoryItem InventoryItem
    {
        get
        {
            _invItem.ItemSprite = m_itemSprite;
            _invItem.ItemId = m_itemId;
            _invItem.ItemMaxStack = m_itemMaxStack;
            _invItem.ItemName = m_itemName;
            return _invItem;
        }
    }

    public InventoryItem GetInventoryItem()
        {
            //check everything is defined, if not debug for now (throw exception later)
            //if everything is good return the inventory item
            return InventoryItem;

            //TODO: 

        }
    }

