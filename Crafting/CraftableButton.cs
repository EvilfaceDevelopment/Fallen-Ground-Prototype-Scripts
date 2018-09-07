using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftableButton : MonoBehaviour 
{

	
    public int ItemId;
    public string ItemName;
    public Sprite ItemSprite;
    public GameObject ImgObject;
	
	void Start ()
	{
	    Button b = GetComponent<Button>();
        b.onClick.AddListener(BtnClicked);
	}

    public void BtnClicked()
    {
        Debug.Log("clicked");
        GameManager.Instance.QCraftManager.GenerateQuickCraftData(ItemId);
    }

    // Update is called once per frame
	void Update ()
	{
	    ImgObject.GetComponentInChildren<Image>().sprite = ItemSprite;
	    GetComponentInChildren<Text>().text = ItemName;

	}
    
    
}
