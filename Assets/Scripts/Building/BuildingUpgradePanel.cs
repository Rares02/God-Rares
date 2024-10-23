using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgradePanel : BuildingPanel
{
    [SerializeField] private BuildingUpgradeButton upgradeButton;
    [SerializeField] private BuildingUpgradeButton removeButton;
    public void UpgradeBuilding() {
        CurrentCell.SetNewBuilding(GameManager.Instance.GetNexLevel(CurrentCell.CellData.CurrentBuilding));
        CloseMenu();
    }

    public void RemoveBuilding() {
        CurrentCell.SetNewBuilding(null);
        CloseMenu();
    }

    public override void OpenPanel(ExagoneCell exagoneCell) {
        base.OpenPanel(exagoneCell);
        if(CurrentCell.CellData.CurrentBuilding.Level == CurrentCell.CellData.CurrentBuilding.MaxLevel) {
            upgradeButton.gameObject.SetActive(false);
        }
        else {
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
