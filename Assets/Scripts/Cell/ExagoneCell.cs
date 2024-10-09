using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExagoneCell : MonoBehaviour {
    private Building currentBuilding;
    public Building CurrentBuilding => currentBuilding; 
    public BuildingViewer buildingViewer;

    public void OnClick() {
        buildingViewer.SetClickUIForBuildingCell(this);
    }
    public void OnSelect() {
        HighLightCell();
        buildingViewer.SetSelectUIForBuildingCell(this);
    }

    public void SetNewBuilding(Building building) {
        currentBuilding = building;
        UpdateBuildingPrefab(building.gameObject);
    }

    private void UpdateBuildingPrefab(GameObject prefab) {
        if(transform.childCount != 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
        Instantiate(prefab, transform);
    }

    private void HighLightCell() {
        
    }
}

