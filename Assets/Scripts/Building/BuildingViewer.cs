using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewer : MonoBehaviour
{
    public BuildingInfoPanel infoPanel;
    public BuildingMenuPanel menuPanel;
    public void SetClickUIForBuildingCell(ExagoneCell currentCell) {
        if(currentCell.CurrentBuilding == null) {
            menuPanel.OpenMenu(currentCell);
            infoPanel.ClosePermanentInfo();
        }
        else {
            menuPanel.CloseMenu();
            infoPanel.OpenPermanentInfo();
        }
    }
    public void SetSelectUIForBuildingCell(ExagoneCell currentCell) {
        if (currentCell.CurrentBuilding == null) {
            infoPanel.CloseTemporaryInfo();
        }
        else {
            infoPanel.OpenTemporaryInfo();
        }
    }
    public void CloseAllPanels() {
        infoPanel.ClosePermanentInfo();
        menuPanel.CloseMenu();
    }
}
