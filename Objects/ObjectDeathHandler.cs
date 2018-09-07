using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeathHandler : MonoBehaviour
{

    public GameObject ItemToDrop;
    public int AmountToDrop;
    public Transform ParentTransform;
    public bool DropsItems;


    public void Start()
    {
        ParentTransform = transform;
    }


    public void Execute()
    {
        if (DropsItems)
        {
            for (int i = 0; i < AmountToDrop; i++)
            {
#pragma warning disable 0219
                GameObject ItemInstance = Instantiate(ItemToDrop, new Vector3(gameObject.transform.position.x + (i * 2), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
#pragma warning restore 0219
                Destroy(gameObject);
            }
        }
    }

}
