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
        GameObject prefabTemp = Instantiate(prefab, transform);
        prefabTemp.name = prefab.name;
        Building buildingTemp = prefabTemp.GetComponent<Building>();

        switch (buildingTemp.name.ToLower()) {
            case "house":
                ResourceManager.Instance.HouseList.Add(buildingTemp);
                break;
            case "statue":
                ResourceManager.Instance.StatueList.Add(buildingTemp);
                break;
            case "temple":
                ResourceManager.Instance.TempleList.Add(buildingTemp);
                break;
            case "market":
                ResourceManager.Instance.MarketList.Add(buildingTemp);
                break;
            default:
                break;
        }
    }

    private void HighlightCell() {
        
    }
    private void DehighlightCell() {

    }
}

