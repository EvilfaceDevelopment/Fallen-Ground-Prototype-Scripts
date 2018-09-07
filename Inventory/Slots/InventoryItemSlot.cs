using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Slots
{
    public class InventoryItemSlot: MonoBehaviour//Used purely by the Inventory UI / Player Inventory back end.
    {
        public GameObject item
        {
            get
            {
                if (transform.childCount > 0)
                {
                    return transform.GetChild(0).gameObject;
                }
                return null;
            }

        }
        //if this doesn't work i'm going to seizure.
        public int ItemId;
        public int? ItemMaxStack;
        public Text CurrentStackText;
        public int CurrentItemStackAmount;
        public Image ItemImage;
        public Sprite ItemSprite;
        public InventoryItem _currentItem;

        public void Awake()
        {
        
            CurrentStackText = GetComponentInChildren<Text>();



        }

   

        public void Start()
        {
        }

        void Update()
        {
            if (_currentItem != null)
            {
                if (_currentItem.ItemId != 0)
                {
                    ItemId = _currentItem.ItemId;
                    CurrentItemStackAmount = _currentItem.CurrentItemStack;
                    CurrentStackText.text = _currentItem.CurrentItemStack.ToString();
                    ItemMaxStack = _currentItem.ItemMaxStack;
                    GetComponentInChildren<Image>().sprite = _currentItem.ItemSprite;
                }
            }
        }

        
    }
}
