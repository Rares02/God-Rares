using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExagoneCell : MonoBehaviour {
    [SerializeField] private ExagoneCellData cellData;

    public ExagoneCellData CellData => cellData;

    
    private BuildingViewer buildingViewer => UISystem.Instance.BuildingViewer;

    private Material material;

    private void Awake() {
        material = GetComponent<MeshRenderer>().material;
    }

    public void OnClick() {
        SelectCell();
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
    private void SelectCell() {
        material.SetFloat("_Highlight", 1);
    }
    private void HighlightCell() {
        material.SetFloat("_Highlight", 0.5f);
    }
    private void DehighlightCell() {
        material.SetFloat("_Highlight", 0);
    }
}

