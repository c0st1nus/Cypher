using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlane : MonoBehaviour
{
    public Item item;
    public Inventory gamemanager;
    public void OnClickEnter()
    {
        print("entered");
        gamemanager.InventoryPlane = this;
    }
    public void OnClickExit()
    {
        gamemanager.InventoryPlane = null;
    }
}
