using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType{ Hpotion, Potion}
public class Item : MonoBehaviour
{
    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int maxSize;
    public void Use()
    {
        switch (type)
        {
            case ItemType.Hpotion:
                break;
            case ItemType.Potion:
                break;
        }
    }
}
