using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableContainerManager : MonoBehaviour
{
    public static LootableContainer CurrentContainer;

    public void Start()
    {
        CurrentContainer = null;
    }
    /* 1) create a public static reference to the "current lootable container" 
     * 2) populate lootable UI with ^ items
     * 3) open up the lootable inventory UI
     * 4) players are gonna instinctively press the "inventory" button to exit out
     * -) which means i need to make the inventory input more robust.
     *
     */








}
