using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour {

	// Use this for initialization
    public Slot[] UISlots;
    public Transform UiParentTransform;
	void Start ()
	{
	    UISlots = UiParentTransform.GetComponentsInChildren<Slot>();
	    for (int i = 0; i < UISlots.Length -1; i++)
	    {
	        UISlots[i].img = GameManager.Instance.InvManager.AllInventoryItems[i].ItemSprite;
	        UISlots[i].inventoryID = i;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < UISlots.Length -1; i++)
	    {
	        UISlots[i].img = GameManager.Instance.InvManager.AllInventoryItems[i].ItemSprite;
	        UISlots[i].inventoryID = i;
	    }
    }
}
