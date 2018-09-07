using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Tool,
    Building,
    Consumable,
    Empty
}
public class CategoriesButton : MonoBehaviour 
{
    

    public ItemType CorrespondingItemType;

    public void SetCurrentCategory()
    {
        GameManager.Instance.QCraftManager.SetCurrentCategoryType(CorrespondingItemType);
    }

    


}
