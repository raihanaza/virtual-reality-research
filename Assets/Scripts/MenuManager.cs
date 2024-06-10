using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu; 

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            Debug.Log("Menu active: " + menu.activeSelf);
        } 
        else
        {
            menu.SetActive(menu.activeSelf);
            Debug.Log("Menu GameObject is not assigned.");
        }
    }
}
