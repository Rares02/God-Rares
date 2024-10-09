using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuPanel : BuildingPanel {
    private ExagoneCell currentCell;

    private Building[] buildings = new Building[2] { new Building(), null};
    public void BuyBuilding(int index) {
        currentCell.SetNewBuilding(buildings[index]);
    }
    public void OpenMenu(ExagoneCell exagoneCell) {
        currentCell = exagoneCell;
        gameObject.SetActive(true);
    }
    public void CloseMenu() {
        gameObject.SetActive(false);
    }
}
