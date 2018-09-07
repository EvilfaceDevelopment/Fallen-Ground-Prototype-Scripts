using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour {

    // Use this for initialization
    public GameObject invUI;
    public GameObject Hotbar;
    private bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isActive = !isActive;
        }

        if (isActive)
        {
            invUI.gameObject.SetActive(true);
            Hotbar.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            invUI.SetActive(false);
            Hotbar.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}
