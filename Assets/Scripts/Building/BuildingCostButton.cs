using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCostButton : GenericButton
{
    [SerializeField] private GenericText[] buildingCostTitle;
    [SerializeField] private GenericText[] buildingCost;

    public void SetCosts(Dictionary<ResourceType, int> cost) {
        ActivateMoneyText(cost);
        ActivateFaithText(cost);
        ActivateFollowersText(cost);
    }

    private void ActivateMoneyText(Dictionary<ResourceType, int> cost) {
        if (cost[ResourceType.Money] != 0) {
            buildingCostTitle[0].SetText(ResourceType.Money.ToString());
            buildingCost[0].SetText(cost[ResourceType.Money]);
            buildingCostTitle[0].gameObject.SetActive(true);
            buildingCost[0].gameObject.SetActive(true);
        }
        else {
            buildingCostTitle[0].gameObject.SetActive(false);
            buildingCost[0].gameObject.SetActive(false);
        }
    }
    private void ActivateFaithText(Dictionary<ResourceType, int> cost) {
        if (cost[ResourceType.Faith] != 0) {
            buildingCostTitle[1].SetText(ResourceType.Faith.ToString());
            buildingCost[1].SetText(cost[ResourceType.Faith]);
            buildingCostTitle[1].gameObject.SetActive(true);
            buildingCost[1].gameObject.SetActive(true);
        }
        else {
            buildingCostTitle[1].gameObject.SetActive(false);
            buildingCost[1].gameObject.SetActive(false);
        }
    }
    private void ActivateFollowersText(Dictionary<ResourceType, int> cost) {
        if (cost[ResourceType.Followers] != 0) {
            buildingCostTitle[2].SetText(ResourceType.Followers.ToString());
            buildingCost[2].SetText(cost[ResourceType.Followers]);
            buildingCostTitle[2].gameObject.SetActive(true);
            buildingCost[2].gameObject.SetActive(true);
        }
        else {
            buildingCostTitle[2].gameObject.SetActive(false);
            buildingCost[2].gameObject.SetActive(false);
        }
    }
}
