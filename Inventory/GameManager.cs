
using Assets.Scripts;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //instance
    public InventoryManager InvManager;
    public HotbarManager Hotmanager;
    public QuickCraftManager QCraftManager;
    public PlayerStatsController StatsController;
    [SerializeField] private ItemDatabase _itemDBInstance; //ALL ITEMS

    //create player inventory with logic

    public InventoryItem TempinvItem;

    public ItemDatabase ItemDBInstance
    {
        get { return _itemDBInstance; }
    }


    public void Awake()
    {
        if (!Instance)
            Instance = this;
        //LoadScriptableObject<ItemDatabase>();
    }

    public static T LoadScriptableObject<T>() where T : ScriptableObject
    {
        System.Type type = typeof(T);
        return Resources.Load<T>(type.ToString());
    }


    //Get Item by ID from DB
    public GameObject GetHandObjectById(int id)
    {
        GameObject Go = null;
        foreach (GameObject go in Hotmanager.HandObjects)
        {
            if (go.GetComponentInChildren<ObjectDefinition>().ItemId == id)
            {
               // Debug.Log("Hand Object was found and returned");
                Go = go;
            }

        }

        return Go;
    }

    public ItemData GetItemDataById(int id)
    {
        ItemData itmd = null;
        foreach (ItemData i in _itemDBInstance.DatabaseItems)
        {
            if (i.ItemId == id) itmd = i;
        }
        return itmd;

    }

    public InventoryItem GetInventoryItemById(int id)
    {
        //find a way to reduce O Complexity
        InventoryItem inv = null;
        foreach (ItemData i in _itemDBInstance.DatabaseItems)
        {
            if (i.ItemId == id) inv = i.GetInventoryItem();

        }

        return inv ?? inv;
    }



}
