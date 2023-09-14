using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public KeyCode InventoryKey;
    public bool InventoryOpened = false;
    public InventoryPlane InventoryPlane;
    public void Awake()
    {
        InventoryKey = KeyCode.Tab;
    }
    private void Update()
    {
        if(Input.GetKey(InventoryKey))
        {
            Cursor.visible = true;
            Time.timeScale = 0.25f;
            foreach(var item in inventory)
            {
                item.SetActive(true);
            }
            if(InventoryPlane != null)
            {
                InventoryPlane.gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
            }
            else if(InventoryPlane == null)
            {
                foreach (var inv in inventory)
                {
                    inv.GetComponent<Image>().color = new Color(255f, 255f, 255f);
                }
            }
        }
        if(Input.GetKeyUp(InventoryKey))
        {
            Cursor.visible = false;
            Time.timeScale = 1.0f;
            foreach (var item in inventory)
            {
                item.SetActive(false);
            }
        }
    }
}
