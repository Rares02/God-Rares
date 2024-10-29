using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private BuildingPanel[] panels;


    private static UISystem instance;
    public static UISystem Instance {
        get {
            instance = FindFirstObjectByType<UISystem>();
            return instance;
        }
    }

    public void CloseOtherPanels(BuildingPanel buildingPanel) {
        foreach (BuildingPanel panel in panels) {
            if (panel != buildingPanel) {
                panel.gameObject.SetActive(false);
            }
        }
    }
}
