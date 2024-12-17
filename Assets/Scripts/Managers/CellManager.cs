using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{

    public void Initialize() {
        for (int i = 0; i < transform.childCount; i++) {
            ExagoneCell cell = transform.GetChild(i).GetComponent<ExagoneCell>();
            if (cell.CellData.CurrentBuilding != null) {
                foreach(BuildingSOType buildingTypes in GameManager.Instance.Buildings.BuildingTypes) {
                    if(cell.CellData.CurrentBuilding.BuildingType == buildingTypes.Type) {
                        cell.CellData.SetBuilding(buildingTypes.BuildingsLevels[0]);
                    }
                }                
            }
        }
    }

    private void Update() {
        if(InputManager.TryRaycast(4000, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default")) {
                if (hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                    exagoneCell.OnSelect();
                }
            }
            else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Water")) {
                UISystem.Instance.BuildingViewer.infoPanel.CloseTemporaryInfo();
            }
        }
    }


}
