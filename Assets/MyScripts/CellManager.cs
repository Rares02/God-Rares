using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public BuildingViewer bv;
    private void Update() {
        if(InputManager.TryRayOnTerrain(4000, layerMask, out RaycastHit hit)) {
            if(hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                exagoneCell.OnSelect();
            }
            
        }
        else {
            bv.infoPanel.CloseTemporaryInfo();
        }

    }
}
