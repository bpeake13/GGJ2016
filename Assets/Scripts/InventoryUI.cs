using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    GameObject Player;

    public Image HeadImage;
    public GameObject HeadItem = null;

    public Image LeftLegImage;
    public GameObject LeftLegItem = null;

    public Image RightLegImage;
    public GameObject RightLegItem = null;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setHeadSlot(GameObject item)
    {
        if (HeadItem != null) { 
            dropHeadSlot();
        }

        HeadItem = item;
        HeadImage.sprite = HeadItem.GetComponent<InventoryItem>().getImage();
        HeadItem.SetActive(false);
    }

    public void dropHeadSlot()
    {
        HeadItem.GetComponent<InventoryItem>().droppedBackIntoWorld(Player.transform.position);
        HeadItem = null;
    }

    public void setLegSlot(GameObject item)
    {
        if (LeftLegItem != null && RightLegItem != null)
        {
            dropRightLegSlot();
            RightLegItem = LeftLegItem;
            RightLegImage.sprite = LeftLegImage.sprite;

            LeftLegItem = item;
            LeftLegImage.sprite = LeftLegItem.GetComponent<InventoryItem>().getImage();
            LeftLegItem.SetActive(false);
        }
        else if(LeftLegItem == null)
        {
            LeftLegItem = item;
            LeftLegImage.sprite = LeftLegItem.GetComponent<InventoryItem>().getImage();
            LeftLegItem.SetActive(false);
        }
        else if (RightLegItem == null)
        {
            RightLegItem = item;
            RightLegImage.sprite = item.GetComponent<InventoryItem>().getImage();
            RightLegItem.SetActive(false);
        }
    }

    public void dropLeftLegSlot()
    {
        LeftLegItem.GetComponent<InventoryItem>().droppedBackIntoWorld(Player.transform.position);
        LeftLegItem = null;
    }
    public void dropRightLegSlot()
    {
        RightLegItem.GetComponent<InventoryItem>().droppedBackIntoWorld(Player.transform.position);
        RightLegItem = null;
    }
}
