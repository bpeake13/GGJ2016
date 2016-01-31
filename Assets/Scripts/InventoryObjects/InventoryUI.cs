using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public GameObject PlayerInFocus;
    public InventoryModelUI inventoryModelUI;

 //   public Image HeadImage;
    GameObject HeadItem = null;

  //  public Image BodyImage;
    GameObject BodyItem = null;

  //  public Image LeftLegImage;
    GameObject LeftLegItem = null;

  //  public Image RightLegImage;
    GameObject RightLegItem = null;

 //   public Image LeftArmImage;
    GameObject LeftArmItem = null;

  //  public Image RightArmImage;
    GameObject RightArmItem = null;

    // Use this for initialization
    void Start () {
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
    //    HeadImage.sprite = HeadItem.GetComponent<InventoryItem>().getImage();
        HeadItem.SetActive(false);
        inventoryModelUI.SetHeadModel(HeadItem.GetComponent<HeadInventoryItem>());
    }

    public void dropHeadSlot()
    {
        HeadItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        HeadItem = null;
    }

    public void setBodySlot(GameObject item)
    {
        if (BodyItem != null)
        {
            dropBodySlot();
        }

        BodyItem = item;
   //     BodyImage.sprite = BodyItem.GetComponent<InventoryItem>().getImage();
        BodyItem.SetActive(false);
        inventoryModelUI.SetBodyModel(BodyItem.GetComponent<BodyInventoryItem>());
    }

    public void dropBodySlot()
    {
        BodyItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        BodyItem = null;
    }

    public void setLegSlot(GameObject item)
    {
        if (LeftLegItem != null && RightLegItem != null)
        {
            dropRightLegSlot();
            RightLegItem = LeftLegItem;
   //         RightLegImage.sprite = LeftLegImage.sprite;

            LeftLegItem = item;
   //         LeftLegImage.sprite = LeftLegItem.GetComponent<InventoryItem>().getImage();
            LeftLegItem.SetActive(false);
            inventoryModelUI.SetLeftLegModel(item.GetComponent<LegInventoryItem>());
        }
        else if(LeftLegItem == null)
        {
            LeftLegItem = item;
   //         LeftLegImage.sprite = LeftLegItem.GetComponent<InventoryItem>().getImage();
            LeftLegItem.SetActive(false);
            inventoryModelUI.SetLeftLegModel(item.GetComponent<LegInventoryItem>());
        }
        else if (RightLegItem == null)
        {
            RightLegItem = item;
   //         RightLegImage.sprite = item.GetComponent<InventoryItem>().getImage();
            RightLegItem.SetActive(false);
            inventoryModelUI.SetRightLegModel(item.GetComponent<LegInventoryItem>());
        }
    }

    public void dropLeftLegSlot()
    {
        LeftLegItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        LeftLegItem = null;
    }
    public void dropRightLegSlot()
    {
        RightLegItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        RightLegItem = null;
    }

    public void setArmSlot(GameObject item)
    {
        if (LeftArmItem != null && RightArmItem != null)
        {
            dropRightArmSlot();
            RightArmItem = LeftArmItem;
   //         RightArmImage.sprite = LeftArmImage.sprite;

            LeftArmItem = item;
    //        LeftArmImage.sprite = LeftArmItem.GetComponent<InventoryItem>().getImage();
            LeftArmItem.SetActive(false);
            inventoryModelUI.SetLeftArmModel(item.GetComponent<ArmInventoryItem>());
        }
        else if (LeftArmItem == null)
        {
            LeftArmItem = item;
   //         LeftArmImage.sprite = LeftArmItem.GetComponent<InventoryItem>().getImage();
            LeftArmItem.SetActive(false);
            inventoryModelUI.SetLeftArmModel(item.GetComponent<ArmInventoryItem>());
        }
        else if (RightArmItem == null)
        {
            RightArmItem = item;
     //       RightArmImage.sprite = item.GetComponent<InventoryItem>().getImage();
            RightArmItem.SetActive(false);
            inventoryModelUI.SetRightArmModel(item.GetComponent<ArmInventoryItem>());
        }
    }

    public void dropLeftArmSlot()
    {
        LeftArmItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        LeftArmItem = null;
    }
    public void dropRightArmSlot()
    {
        RightArmItem.GetComponent<InventoryItem>().droppedBackIntoWorld(PlayerInFocus.transform.position);
        RightArmItem = null;
    }
}
