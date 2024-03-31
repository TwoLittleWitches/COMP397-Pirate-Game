using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private bool panelVisible = false;
    private void Start()
    {
        panel.SetActive(panelVisible);
    }
    public void OpenPanel()
    {
        if(panelVisible == false)
        {
            Debug.Log("Inventory Open");
            panelVisible = true;
            panel.SetActive(panelVisible);
        }
        else
        {
            Debug.Log("Inventory Close");
            panelVisible = false;
            panel.SetActive(panelVisible);
        }
    }
}
