using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRemover : ItemPlugin
{
    public int amountToRemove;
    public override void Use(RaycastHit hit)
    {
        Debug.Log(hit.transform.name);
        if (hit.transform.GetComponent<Health>())
        {
            hit.transform.GetComponent<Health>().Run(amountToRemove);
        }
    }

}
