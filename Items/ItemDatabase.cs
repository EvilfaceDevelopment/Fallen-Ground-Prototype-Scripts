using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ItemDatabase : MonoBehaviour
    {

        //Array of ItemData's
         [SerializeField]
         List<ItemData> _databaseItems;

        public List<ItemData> DatabaseItems
        {
            get { return _databaseItems; }
        }

        







    }
}
	
