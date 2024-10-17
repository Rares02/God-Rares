using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuPanel : BuildingPanel {
    private ExagoneCell currentCell;
    [SerializeField] private BuildingMenuButton button;
    [SerializeField] private GameObject content;
    public void BuyBuilding(int index) {
        currentCell.SetNewBuilding(GameManager.Instance.Buildings[index]);
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
        for (int i = 0; i < GameManager.Instance.Buildings.Length; i++){
            BuildingMenuButton newButton = Instantiate(button, content.transform);
            int index = i;
            newButton.OnClick_Get.AddListener(() => { BuyBuilding(index); });
        }
    }

    public void ClearButtons() {
        foreach (Transform child in content.transform) {
            Destroy(child.gameObject);
        }
    }
}
