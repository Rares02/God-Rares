using System;
using TMPro;
using UnityEngine;

public class BuildingInfoPanel : BuildingPanel {
    [SerializeField] private TextMeshProUGUI cellType;
    [SerializeField] private TextMeshProUGUI terrainType;
    [SerializeField] private BuildingInfoParameters buildingInfoParameters;
    private bool permanent;
    public void SetPermanent() {
        permanent = true;
    }
    public void SetTemporary() {
        permanent = false;
    }
    public void OpenPermanentInfo() {
        gameObject.SetActive(true);
        SetPermanent();
    }
    public void OpenTemporaryInfo(ExagoneCell exagoneCell) {
        SetupInfo(exagoneCell);
        if(!permanent) gameObject.SetActive(true);
    }
    public void CloseTemporaryInfo() {
        if (!permanent) {
            gameObject.SetActive(false);
        }
    }
    public void ClosePermanentInfo() {
        gameObject.SetActive(false);
        SetTemporary();
    }
    private void SetupInfo(ExagoneCell exagoneCell) {
        //cellType.text = UIText.INFO_PANEL_CELL_EMPTY;
        //terrainType.text = exagoneCell.CellData.TerrainType.ToString();
        //if (exagoneCell.CellData.CurrentBuilding != null) {
        //    cellType.text = exagoneCell.CellData.CurrentBuilding.name;
        //    buildingInfoParameters.SetupInfo(exagoneCell.CellData);
        //}
    }
}
