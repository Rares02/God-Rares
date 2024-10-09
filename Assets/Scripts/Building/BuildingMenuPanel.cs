using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuPanel : BuildingPanel {
    private ExagoneCell currentCell;

    [SerializeField] private Building[] buildings;
    public void BuyBuilding(int index) {
        currentCell.SetNewBuilding(buildings[index]);
        CloseMenu();
    }
    public void OpenMenu(ExagoneCell exagoneCell) {
        currentCell = exagoneCell;
        gameObject.SetActive(true);
    }
    public void CloseMenu() {
        gameObject.SetActive(false);
    }
}
