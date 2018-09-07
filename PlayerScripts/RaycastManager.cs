#pragma warning disable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{

    public Camera camera;


    void Start()
    {
    }

    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

           // Add lootable box support
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (hit.transform.name != "FPSController")
                {
                   Debug.Log(hit.transform.name);

                    if (hit.transform.GetComponentInChildren<ItemPickup>())
                    {
                        Debug.Log("Executed on object of type " + hit.transform.name);
                        hit.transform.GetComponentInChildren<ItemPickup>().Execute();
                    }
               

                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Called the command");
                GameManager.Instance.Hotmanager.UseCurrentObjectInHand(hit);
            }

        }

    }
}


