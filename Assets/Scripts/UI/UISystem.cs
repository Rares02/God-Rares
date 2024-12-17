using System.Collections.Generic;
using UnityEngine;
public class UISystem : MonoBehaviour
{
    [SerializeField] private BuildingViewer buildingViewer;

    public BuildingViewer BuildingViewer => buildingViewer;
    public List<UIViewer> Viewers => new List<UIViewer>() { BuildingViewer };

    private static UISystem instance;
    public static UISystem Instance {
        get {
            instance = instance == null? FindFirstObjectByType<UISystem>() : instance;
            return instance;
        }
    }

    public void CloseOtherPanels(BuildingPanel buildingPanel) {
        foreach (UIViewer viewer in Viewers) {
            foreach(UIPanel panel in viewer.Panels) {
                if (panel != buildingPanel) {
                    panel.gameObject.SetActive(false);
                }
            }
        }
    }
}
