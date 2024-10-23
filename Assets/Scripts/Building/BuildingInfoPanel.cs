using System;
using TMPro;
using UnityEngine;

public class BuildingInfoPanel : BuildingPanel {
    private ExagoneCellData lastInfo = new ExagoneCellData();
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
    public void OpenPermanentInfo(ExagoneCell exagoneCell) {
        SetupInfo(exagoneCell.CellData);
        gameObject.SetActive(true);
        SetPermanent();
    }
    public void OpenTemporaryInfo(ExagoneCell exagoneCell) {        
        if (!permanent) {
            SetupInfo(exagoneCell.CellData);
            gameObject.SetActive(true);
        }
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
    public void SetupInfo(ExagoneCellData exagoneCellData) {
        if (terrainType.text != exagoneCellData.TerrainType.ToString()) {
            terrainType.text = exagoneCellData.TerrainType.ToString();
        }
        if (exagoneCellData.CurrentBuilding == null && lastInfo.CurrentBuilding == null) {
            lastInfo = exagoneCellData;
            return;
        }
        if (exagoneCellData.CurrentBuilding == null) {            
            cellType.text = UIText.INFO_PANEL_CELL_EMPTY;
            buildingInfoParameters.SetupEmptyInfo();
        }
        else {
            if(lastInfo.CurrentBuilding != null) {
                if (exagoneCellData.CurrentBuilding.name == lastInfo.CurrentBuilding.name &&
                exagoneCellData.CurrentBuilding.Level == lastInfo.CurrentBuilding.Level) {
                    return;
                }
            }            
            cellType.text = exagoneCellData.CurrentBuilding.BuildingType.ToString();
            buildingInfoParameters.SetupInfo(exagoneCellData);
        }
        lastInfo = exagoneCellData;
    }

    public void UpdateCurrentInfo() {
        if (terrainType.text != lastInfo.TerrainType.ToString()) {
            terrainType.text = lastInfo.TerrainType.ToString();
        }
        if (lastInfo.CurrentBuilding != null) {
            cellType.text = lastInfo.CurrentBuilding.BuildingType.ToString();
            buildingInfoParameters.SetupInfo(lastInfo);
        }
        else {
            cellType.text = UIText.INFO_PANEL_CELL_EMPTY;
            buildingInfoParameters.SetupEmptyInfo();
        }
    }
}
