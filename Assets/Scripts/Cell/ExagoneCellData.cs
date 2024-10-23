using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExagoneCellData {
    private BuildingSO lastBuilding;
    [SerializeField] private BuildingSO building;
    [SerializeField] private TerrainType terrainType;
    [SerializeField] private bool isRemovable;
    public BuildingSO CurrentBuilding => building;
    public TerrainType TerrainType => terrainType;
    public bool IsRemovable => isRemovable;

    public void SetBuilding(BuildingSO building) {
        SetNewParameters(building);
        this.building = building;        
        lastBuilding = this.building;
    }

    public void SetNewParameters(BuildingSO building) {
        if (building != null) {
            switch (building.BuildingType) {
                case BuildingType.House:
                    ResourceManager.Instance.HouseList.Add(building);
                    break;
                case BuildingType.Statue:
                    ResourceManager.Instance.StatueList.Add(building);
                    break;
                case BuildingType.Temple:
                    ResourceManager.Instance.TempleList.Add(building);
                    break;
                case BuildingType.Market:
                    ResourceManager.Instance.MarketList.Add(building);
                    break;
            }

            ResourceManager.Instance.Money.Max += building.Capacity[ResourceType.Money];
            ResourceManager.Instance.Faith.Max += building.Capacity[ResourceType.Faith];
            ResourceManager.Instance.Followers.Max += building.Capacity[ResourceType.Followers];
        }
        if(lastBuilding != null) {
            switch (lastBuilding.BuildingType) {
                case BuildingType.House:
                    ResourceManager.Instance.HouseList.Remove(building);
                    break;
                case BuildingType.Statue:
                    ResourceManager.Instance.StatueList.Remove(building);
                    break;
                case BuildingType.Temple:
                    ResourceManager.Instance.TempleList.Remove(building);
                    break;
                case BuildingType.Market:
                    ResourceManager.Instance.MarketList.Remove(building);
                    break;
            }

            ResourceManager.Instance.Money.Max -= lastBuilding.Capacity[ResourceType.Money];
            ResourceManager.Instance.Faith.Max -= lastBuilding.Capacity[ResourceType.Faith];
            ResourceManager.Instance.Followers.Max -= lastBuilding.Capacity[ResourceType.Followers];
        }
    }
}
