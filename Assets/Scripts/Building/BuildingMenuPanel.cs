using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuPanel : BuildingPanel {
    
    [SerializeField] private BuildingMenuButton button;
    [SerializeField] private GameObject content;
    public void BuyBuilding(int index) {
        BuildingSO selectedBuilding = GameManager.Instance.Buildings.BuildingTypes[index].BuildingsLevels[0];
        if (ResourceManager.Instance.HaveEnoughResources(selectedBuilding.Cost)) {
            CurrentCell.SetNewBuilding(selectedBuilding);
            CloseMenu();
        }
    }
    public override void OpenPanel(ExagoneCell exagoneCell) {
        base.OpenPanel(exagoneCell);
        GenerateButtonList();
    }
    
    private void GenerateButtonList() {
        ClearButtons();
        for (int i = 0; i < GameManager.Instance.Buildings.BuildingTypes.Count; i++){
            BuildingSO building = GameManager.Instance.Buildings.BuildingTypes[i].BuildingsLevels[0];
            if (!building.IsBuyable) continue;
            BuildingMenuButton newButton = Instantiate(button, content.transform);
            newButton.BuindingName.SetText(building.BuildingType.ToString());
            newButton.SetCosts(building.Cost);
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
