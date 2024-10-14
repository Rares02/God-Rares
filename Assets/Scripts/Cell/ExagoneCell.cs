using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExagoneCell : MonoBehaviour {
    [SerializeField] private ExagoneCellData cellData;

    public ExagoneCellData CellData => cellData;

    public BuildingViewer buildingViewer;

    public void OnClick() {
        buildingViewer.SetClickUIForBuildingCell(this);
    }
    public void OnSelect() {
        HighlightCell();
        buildingViewer.SetSelectUIForBuildingCell(this);
    }
    public void OnDeselect() {
        DehighlightCell();
    }

    public void SetNewBuilding(Building building) {
        cellData.SetBuilding(building);
        UpdateBuildingPrefab(building.gameObject);
    }

    private void UpdateBuildingPrefab(GameObject prefab) {
        if(transform.childCount != 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
        GameObject temp = Instantiate(prefab, transform);
        temp.name = prefab.name;
    }

    private void HighlightCell() {
        
    }
    private void DehighlightCell() {

    }
}

