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
        buildingViewer.SetSelectUIForBuildingCell(this);
    }

    public void SetNewBuilding(Building building) {
        currentBuilding = building;
        UpdateBuildingPrefab(building.Prefab);
    }

    private void UpdateBuildingPrefab(GameObject prefab) {
        if(transform.childCount != 0) {
            Destroy(transform.GetChild(0));
        }
        Instantiate(prefab, transform);
    }
}


public class Building {
    public GameObject Prefab;
}

