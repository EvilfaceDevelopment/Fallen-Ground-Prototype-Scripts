using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IDropHandler
{

    public Sprite img;
    public string text;
    public int inventoryID; //reference to corresponding Inventory(data)
    [SerializeField]
    private InventoryItem _itemToBecome;

    public InventoryItem ItemToBecome
    {
        get
        {
            return _itemToBecome;

        }
        set { _itemToBecome = value; }
    }

    public void OnGUI()
    {
        GetComponentInChildren<Image>().sprite = img;
        GetComponentInChildren<Text>().text = text;
    }

    public void Update()
    {
        text = GameManager.Instance.InvManager.AllInventoryItems[inventoryID].CurrentItemStack.ToString();
        GetComponentInChildren<Image>().sprite = img;
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropping");
        //get the dragged and set it as temp item;

        _itemToBecome = dragscript.TempInventoryItem;

        GameManager.Instance.InvManager.AllInventoryItems[dragscript.itembeingdragged.GetComponentInParent<Slot>().inventoryID] =
            GameManager.Instance.InvManager.AllInventoryItems[inventoryID];
        GameManager.Instance.InvManager.AllInventoryItems[inventoryID] = _itemToBecome;

        _itemToBecome = null;


        


    }

   
}
