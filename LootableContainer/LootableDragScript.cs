using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LootableDragScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Vector3 startposition;
    private Transform startParent;
    public static GameObject itembeingdragged;
    public static InventoryItem TempInventoryItem;

    public void OnBeginDrag(PointerEventData data)
    {
        TempInventoryItem = //TODO: This is disgusting.
            LootableContainerManager.CurrentContainer._containerItems[GetComponentInParent<Slot>().inventoryID];
        startParent = transform.parent;
        itembeingdragged = gameObject;
        startposition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (startParent == transform.parent)
        {
            transform.position = startposition;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        itembeingdragged = null;

    }
}