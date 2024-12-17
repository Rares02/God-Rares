using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private ExagoneCell lastCell;
    private ExagoneCell selectedCell;
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

    public void OnClick() {
        if (InputManager.TryRaycast(4000, out RaycastHit hit)) {
            //Debug.Log(hit.transform.gameObject.layer);
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default")) {
                if (hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                    exagoneCell.OnClick();
                    lastCell = null;
                    if (selectedCell != null && exagoneCell != selectedCell) {
                        selectedCell.OnDeselect();
                    }
                    selectedCell = exagoneCell;
                }
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water")) {
                UISystem.Instance.BuildingViewer.CloseAllPanels();
            }
        }
    }

    private void Update() {
        if(InputManager.TryRaycast(4000, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default")) {
                if (hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                    if (exagoneCell != selectedCell) {
                        exagoneCell.OnSelect();
                        if (lastCell != null && exagoneCell != lastCell) {
                            lastCell.OnDeselect();
                        }
                        lastCell = exagoneCell;
                    }
                    else if(lastCell != null && exagoneCell != lastCell) {
                        lastCell.OnDeselect();
                    }
                }
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water")) {
                UISystem.Instance.BuildingViewer.infoPanel.CloseTemporaryInfo();
                if (lastCell != selectedCell && lastCell != null)
                    lastCell.OnDeselect();
            }
        }
    }


}
