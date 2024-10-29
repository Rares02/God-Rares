using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgradePanel : BuildingPanel
{
    [SerializeField] private BuildingUpgradeButton upgradeButton;
    [SerializeField] private BuildingUpgradeButton removeButton;
    public void UpgradeBuilding() {
        BuildingSO nextLevel = GameManager.Instance.GetNexLevel(CurrentCell.CellData.CurrentBuilding);
        if (ResourceManager.Instance.HaveEnoughResources(nextLevel.Cost)) {
            CurrentCell.SetNewBuilding(nextLevel);
            CloseMenu();
        }
    }

    public void RemoveBuilding() {
        CurrentCell.SetNewBuilding(null);
        CloseMenu();
    }

    public override void OpenPanel(ExagoneCell exagoneCell) {
        base.OpenPanel(exagoneCell);
        if(CurrentCell.CellData.CurrentBuilding.Level == CurrentCell.CellData.CurrentBuilding.MaxLevel + 1) {
            upgradeButton.gameObject.SetActive(false);
        }
        else {
            BuildingSO nextLevel = GameManager.Instance.GetNexLevel(CurrentCell.CellData.CurrentBuilding);
            upgradeButton.SetCosts(nextLevel.Cost);
            upgradeButton.SetLevelText(CurrentCell.CellData.CurrentBuilding.Level);
            upgradeButton.gameObject.SetActive(true);
        }
        if (CurrentCell.CellData.CurrentBuilding.IsBuyable) {
            removeButton.gameObject.SetActive(true);
        }
        else {
            removeButton.gameObject.SetActive(false);
        }
    }
}
