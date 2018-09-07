using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class QuickCraftManager : MonoBehaviour
{
    private ItemType CategoryType { get; set; }
	// Use this for initialization
    [SerializeField]
    private Transform ListItemsParentTransform;

    private int _amountToCraft = 1;
    [SerializeField] private Transform CraftContainerTransform;
    [SerializeField] private Transform RequiredItemsParent;

    [SerializeField] private ItemData CurrentButtonItem;

    [SerializeField] private Image ItemToCraftImage;
    public GameObject listitemprefab;
    public GameObject TableColumnPrefab;

    public GameObject[] CurrentCells;
    public void Start()
    {
        ListItemsParentTransform = transform;
       
    }

    public void OnEnable()
    {
        DestroyOldColumns();
    }

    public void DestroyOldButtons()
    {
        CraftableButton[] buttons;
        buttons =  ListItemsParentTransform.GetComponentsInChildren<CraftableButton>();
        foreach (CraftableButton it in buttons)
        {
            DestroyImmediate(it.gameObject);
        }
    }

    public void DestroyOldColumns()
    {
        RequiredColumnData[] _columns;
        _columns = RequiredItemsParent.GetComponentsInChildren<RequiredColumnData>();
        foreach (RequiredColumnData it in _columns)
        {
            Destroy(it.gameObject);
        }
    }


    public bool HasGotEnoughResources()
    {
        foreach (RequiredItem it in CurrentButtonItem.ItemsRequiredForCrafting)
        {
           int AmountWeHave = GameManager.Instance.InvManager.GetCurrentAmountOfItemByID(it.ItemID);
            if (AmountWeHave < it.AmountRequired) return false;
        }

        return true;
    }


    public void OnCraftButtonClick()
    {
       bool canwecraft = HasGotEnoughResources();
        if (canwecraft)
        {
            foreach (RequiredItem it in CurrentButtonItem.ItemsRequiredForCrafting)
            {
                GameManager.Instance.InvManager.RemoveItemFromInventoryById(it.ItemID, it.AmountRequired);
            }
            GameManager.Instance.InvManager.AddItemToInventoryById(CurrentButtonItem.ItemId,_amountToCraft);
        }

    }

   

    public void GenerateQuickCraftData(int id)
    {
        DestroyOldColumns();
        CurrentButtonItem = GameManager.Instance.GetItemDataById(id);
        ItemToCraftImage.sprite = CurrentButtonItem.InventoryItem.ItemSprite;
        int counter = 0;
        foreach (RequiredItem reqi in CurrentButtonItem.ItemsRequiredForCrafting)
        {
            var temp = Instantiate(TableColumnPrefab,RequiredItemsParent);
            CurrentCells = temp.GetComponent<RequiredColumnData>().Cells; 
            CurrentCells[0].GetComponentInChildren<Text>().text = //Amount needed per item you want to craft
                CurrentButtonItem.ItemsRequiredForCrafting[counter].AmountRequired.ToString();
            CurrentCells[1].GetComponentInChildren<Text>().text = //name of the item
                CurrentButtonItem.ItemsRequiredForCrafting[counter].ItemName;
            int tempamount = CurrentButtonItem.ItemsRequiredForCrafting[counter].AmountRequired;
            CurrentCells[2].GetComponentInChildren<Text>().text = //amount needed to craft X amount
               (tempamount * _amountToCraft).ToString();
            CurrentCells[3].GetComponentInChildren<Text>().text = GameManager.Instance.InvManager.GetCurrentAmountOfItemByID(reqi.ItemID).ToString();
            counter++;
        }
      // SetColumnSpacingForAllColumns();
    }

    public void SetCurrentCategoryType(ItemType type)
    {
        CategoryType = type;
        DestroyOldButtons();
        foreach (ItemData iterator in GameManager.Instance.ItemDBInstance.DatabaseItems)
        {
            if (iterator.Type == CategoryType)
            {
                GameObject temp = Instantiate(listitemprefab, ListItemsParentTransform, false);
                temp.GetComponent<CraftableButton>().ItemId = iterator.ItemId;
                temp.GetComponent<CraftableButton>().ItemName = iterator.InventoryItem.ItemName;
                temp.GetComponent<CraftableButton>().ItemSprite = iterator.InventoryItem.ItemSprite;

            }
        }
    }

}
