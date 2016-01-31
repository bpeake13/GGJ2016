using UnityEngine;
using System.Collections;

public class InventoryModelUI : MonoBehaviour {

    public GameObject arm1L;
    public GameObject arm1R;
    public GameObject arm2L;
    public GameObject arm2R;
    public GameObject arm3L;
    public GameObject arm3R;

    public GameObject leg1L;
    public GameObject leg1R;
    public GameObject leg2L;
    public GameObject leg2R;
    public GameObject leg3L;
    public GameObject leg3R;

    public GameObject head1;
    public GameObject head2;
    public GameObject head3;

    public GameObject body1;
    public GameObject body2;
    public GameObject body3;

    GameObject activeHead = null;
    GameObject activeBody = null;
    GameObject activeArmLeft = null;
    GameObject activeArmRight = null;
    GameObject activeLegLeft = null;
    GameObject activeLegRight = null;

    public HeadInventoryItem headItem;
    public BodyInventoryItem bodyItem;
    public LegInventoryItem leftLegItem;
    public LegInventoryItem rightLegItem;
    public ArmInventoryItem leftArmItem;
    public ArmInventoryItem rightArmItem;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void resetModel()
    {
        arm1L.SetActive(false);
        arm1R.SetActive(false);
        arm2L.SetActive(false);
        arm2R.SetActive(false);
        arm3L.SetActive(false);
        arm3R.SetActive(false);

        leg1L.SetActive(false);
        leg1R.SetActive(false);
        leg2L.SetActive(false);
        leg2R.SetActive(false);
        leg3L.SetActive(false);
        leg3R.SetActive(false);

        head1.SetActive(false);
        head2.SetActive(false);
        head3.SetActive(false);

        body1.SetActive(false);
        body2.SetActive(false);
        body3.SetActive(false);

        activeHead = null;
        activeBody = null;
        activeArmLeft = null;
        activeArmRight = null;
        activeLegLeft = null;
        activeLegRight = null;

        headItem = null;
        bodyItem = null;
        leftLegItem = null;
        rightLegItem = null;
        leftArmItem = null;
        rightArmItem = null;
    }

    public void SetHeadModel(HeadInventoryItem item)
    {
        if (item == null)
        {
            return;
        }

        if(activeHead != null)
        {
            activeHead.SetActive(false);
            activeHead = null;
        }

        switch (item.headType)
        {
            case enums.headType.head1:
                activeHead = head1;
                break;
            case enums.headType.head2:
                activeHead = head2;
                break;
            case enums.headType.head3:
                activeHead = head3;
                break;
        }
        activeHead.SetActive(true);
        headItem = item;
    }

    public void SetBodyModel(BodyInventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        if (activeBody != null)
        {
            activeBody.SetActive(false);
            activeBody = null;
        }

        switch (item.bodyType)
        {
            case enums.bodyType.body1:
                activeBody = body1;
                break;
            case enums.bodyType.body2:
                activeBody = body2;
                break;
            case enums.bodyType.body3:
                activeBody = body3;
                break;
        }
        activeBody.SetActive(true);
        bodyItem = item;
    }

    public void SetLeftLegModel(LegInventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        if (activeLegLeft != null)
        {
            activeLegLeft.SetActive(false);
            activeLegLeft = null;
        }

        switch (item.legType)
        {
            case enums.legType.leg1:
                activeLegLeft = leg1L;
                break;
            case enums.legType.leg2:
                activeLegLeft = leg2L;
                break;
            case enums.legType.leg3:
                activeLegLeft = leg3L;
                break;
        }
        activeLegLeft.SetActive(true);
        leftLegItem = item;
    }

    public void SetRightLegModel(LegInventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        if (activeLegRight != null)
        {
            activeLegRight.SetActive(false);
            activeLegRight = null;
        }

        switch (item.legType)
        {
            case enums.legType.leg1:
                activeLegRight = leg1R;
                break;
            case enums.legType.leg2:
                activeLegRight = leg2R;
                break;
            case enums.legType.leg3:
                activeLegRight = leg3R;
                break;
        }
        activeLegRight.SetActive(true);
        rightLegItem = item;
    }

    public void SetLeftArmModel(ArmInventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        if (activeArmLeft != null)
        {
            activeArmLeft.SetActive(false);
            activeArmLeft = null;
        }

        switch (item.armType)
        {
            case enums.armType.arm1:
                activeArmLeft = arm1L;
                break;
            case enums.armType.arm2:
                activeArmLeft = arm2L;
                break;
            case enums.armType.arm3:
                activeArmLeft = arm3L;
                break;
        }
        activeArmLeft.SetActive(true);
        leftArmItem = item;
    }

    public void SetRightArmModel(ArmInventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        if (activeArmRight != null)
        {
            activeArmRight.SetActive(false);
            activeArmRight = null;
        }

        switch (item.armType)
        {
            case enums.armType.arm1:
                activeArmRight =arm1R;
                break;
            case enums.armType.arm2:
                activeArmRight = arm2R;
                break;
            case enums.armType.arm3:
                activeArmRight = arm3R;
                break;
        }
        activeArmRight.SetActive(true);
        rightArmItem = item;
    }
}
