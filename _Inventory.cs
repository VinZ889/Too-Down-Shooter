using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject player;
    
    public List<Item> list = new List<Item>();

    //added by me
    #region Singleton 

    public static _Inventory instance;
    void Awake()// added by me
    {
        if (instance != null) // added by me
        {
            Debug.LogWarning(" More than one instance of Inventory found!");
            return;
        }// added by me
        instance = this;
    }

    #endregion//added by me
    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;

    void Start()
    {
        updatePanelSlots();
    }

    void updatePanelSlots()
    {
        int index = 0;

        foreach(Transform child in inventoryPanel.transform)
        {
            
            inventorySlotController slot = child.GetComponent<inventorySlotController>();
            
            

            if (index < list.Count)
            {
                slot.item = list[index];
            }
            else
            {
                slot.item = null;
            }

            slot.updateInfo();
            index++;


        }
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (list.Count >= 9)
            {
                Debug.Log("Not enough room");
                return false;
            }
            list.Add(item);
            updatePanelSlots();
            //if (onItemChangedCallback !=null)
                //onItemChangedCallback.Invoke();
        }
        return true;    
    }

    public void Remove(Item item)
    {
        list.Remove(item);
        updatePanelSlots();
        //if (onItemChangedCallback !=null)
        //onItemChangedCallback.Invoke();
    }

 }
