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

    public void SetNewBuilding(BuildingSO building) {
        cellData.SetBuilding(building);
        buildingViewer.UpdateInfoPanel();
        UpdateBuildingPrefab(building);
    }

    private void UpdateBuildingPrefab(BuildingSO building) {
        if(transform.childCount != 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
        if (building != null) {
            GameObject prefabTemp = Instantiate(building.Model, transform);
        }  
    }

    private void HighlightCell() {
        
    }
    private void DehighlightCell() {

    }
}

