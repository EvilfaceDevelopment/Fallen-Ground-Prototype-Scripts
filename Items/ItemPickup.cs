using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool Added;
    public void Execute()
    {
        if (transform.GetComponentInChildren<ObjectDefinition>() && !Added)
        {
            Debug.Log("Definition found");
           GameManager.Instance.InvManager.AddItemToInventoryByInvItem(transform.GetComponentInChildren<ObjectDefinition>().WorldObjectItemData);
            //GameManager.Instance.InvManager.AddItemToInventoryById(transform.GetComponentInChildren<ObjectDefinition>().WorldObjectItemData.ItemId,
            //    transform.GetComponentInChildren<ObjectDefinition>().WorldObjectItemData.CurrentItemStack);
            Added = true;
        }
        Destroy(gameObject);
        Debug.Log("Object Doesn't have a definition");
    }

}
