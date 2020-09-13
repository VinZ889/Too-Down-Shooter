using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private RectTransform inventoryRect;
    private float inventoryWidth, inventoryHeight;
    public int slot;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;
    public GameObject slotPrefab;
    private Slot from, to;// Added after i tested can remove items using right mouse
    private List<GameObject> allSlots;
    private static int emptySlots; // change after invenotry slot able to count up

    public static int EmptySlots// change after invenotry slot able to count up
    {
        get { return emptySlots; }
        set { emptySlots = value; }
    }// change after invenotry slot able to count up

    void Start()
    {
        CreateLayout();
    }

    
    void Update()
    {
        
    }

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();//instantiate
        emptySlots = slot;
        inventoryWidth = (slot / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
        inventoryRect = GetComponent<RectTransform>();
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = slot / rows;
        for (int y =0; y < rows; y++)
        {
            for (int x=0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                newSlot.name = "Slot";
                newSlot.transform.SetParent(this.transform.parent);
                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft + (x + 1) + (slotSize * x),
                                    -slotPaddingTop * (y + 1) - (slotSize * y));
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
                allSlots.Add(newSlot);
            }
        }

    }

    public bool AddItem(Item item)
    {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();
                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type ==item.type && tmp.IsAvailable)
                    {
                        tmp.AddItem(item);
                        emptySlots--;
                        return true;
                    }
                }
            }
            if (emptySlots > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }
    private bool PlaceEmpty(Item item) // Check if there is any empty slot
    {
        if (emptySlots > 0)
        {
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();
                if (tmp.IsEmpty)
                {
                    tmp.AddItem(item);
                    emptySlots--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MoveItem(GameObject clicked)// Added after able to remove items by right click mouse
    {
        if (from == null)
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.grey;
            }
        }
        else if (to == null)
        {
            to = clicked.GetComponent<Slot>();
        }
        if ( to != null && from != null)
        {
            Stack<Item> tmpTo = new Stack<Item>(to.Items);
            to.AddItems(from.Items);

            if (tmpTo.Count ==0)
            {
                from.ClearSlot();
            }
            else
            {
                from.AddItems(tmpTo);
            }
            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
        }
    }
}
