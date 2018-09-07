using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LootableContainer : MonoBehaviour
{
    private int _containerSize = 16; //change this so it isn't a magic number

    public InventoryItem[] _containerItems;
    

    public void Start()
    {
         
        
        _containerItems = new InventoryItem[_containerSize];

        for(int i = 0; i < _containerItems.Length -1; i++) //sets all of the slots to empty, this will do for now
        // however it's gonna need to generate items in the future
        {
          
            _containerItems[i] = GameManager.Instance.GetInventoryItemById(2);
            _containerItems[i].CurrentItemStack = 1;
        }

        
       
    }

    public void Interact()
    {

    }

    /* 1) create function that is called on raycasthit 'e'
     * 2) function checks to make sure container is populated, if not populates
     * 3) container sends an event to the loot UI? idfk
     * 4) UI updates displaying current container and opens
     * 5) unsure whether item switching will automatically work but i'm fairly certain it will bc of how i've done it lmao.
     */




    public void AddItem(int Id)
    {
        bool _added = false;
        foreach (var i in _containerItems)
        {
            while (!_added)
            {
                if (i.ItemId == 1)
                {
                    i.ItemId = Id;
                    Debug.Log("Item Added sucessfully!");
                    _added = true;
                }
            }
        }

        if (!_added)
        {
            Debug.Log("An error occurred while attempting to add item.");

        }
    }
}
