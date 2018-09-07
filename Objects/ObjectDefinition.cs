using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObjectDefinition : MonoBehaviour
{

    public int ItemId;
    public InventoryItem WorldObjectItemData = new InventoryItem();
    [UsedImplicitly]
    public void Start()
    {
        if (ItemId == 0)
        {
            ItemId = 1;
        }

        InventoryItem temp = GameManager.Instance.GetInventoryItemById(ItemId);
        WorldObjectItemData.ItemId = temp.ItemId;
        WorldObjectItemData.CurrentItemStack = 1;
        WorldObjectItemData.ItemMaxStack = temp.ItemMaxStack;
        WorldObjectItemData.ItemName = temp.ItemName;
        WorldObjectItemData.ItemSprite = temp.ItemSprite;
        temp = null; //GC come get me

    }

    public void Update()
    {
       
    }
}
