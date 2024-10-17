using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewer : MonoBehaviour {
    public BuildingInfoPanel infoPanel;
    public BuildingMenuPanel menuPanel;
    public void SetClickUIForBuildingCell(ExagoneCell currentCell) {
        infoPanel.OpenPermanentInfo(currentCell);
        if (currentCell.CellData.CurrentBuilding == null) {            
            menuPanel.OpenMenu(currentCell);
        }
        else {
            menuPanel.CloseMenu();
        }
    }

    public void UpdateInfoPanel() {
        infoPanel.UpdateCurrentInfo();
    }
    public void SetSelectUIForBuildingCell(ExagoneCell currentCell) {
        infoPanel.OpenTemporaryInfo(currentCell);
    }
    public void CloseAllPanels() {
        infoPanel.ClosePermanentInfo();
        menuPanel.CloseMenu();
    }
}
