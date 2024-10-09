using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuPanel : BuildingPanel {
    private ExagoneCell currentCell;
    [SerializeField] private GenericButton button;
    [SerializeField] private GameObject content;

    [SerializeField] private Building[] buildings;
    public void BuyBuilding(int index) {
        currentCell.SetNewBuilding(buildings[index]);
        CloseMenu();
    }
    public void OpenMenu(ExagoneCell exagoneCell) {
        currentCell = exagoneCell;
        GenerateButtonList();
        gameObject.SetActive(true);
    }
    public void CloseMenu() {
        gameObject.SetActive(false);
    }
    private void GenerateButtonList() {
        ClearButtons();
        foreach (var building in buildings) {
            Instantiate(button, content.transform);
        }
    }

    public void ClearButtons() {
        foreach (Transform child in content.transform) {
            Destroy(child.gameObject);
        }
    }
}
