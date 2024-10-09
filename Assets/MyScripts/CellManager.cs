using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public BuildingViewer bv;
    private void Update() {
        if(InputManager.TryRaycast(4000, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default")) {
                if (hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                    exagoneCell.OnSelect();
                }
            }
            else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Water")) {
                bv.infoPanel.CloseTemporaryInfo();
            }
        }
    }
}
