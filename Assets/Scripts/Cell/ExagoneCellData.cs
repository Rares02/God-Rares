using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExagoneCellData {
    [SerializeField] private BuildingSO building;
    [SerializeField] private TerrainType terrainType;
    [SerializeField] private bool isRemovable;
    public BuildingSO CurrentBuilding => building;
    public TerrainType TerrainType => terrainType;
    public bool IsRemovable => isRemovable;

    public void SetBuilding(BuildingSO building) {
        SetNewParameters(building);
        this.building = building;
        
    }

    private void SetNewParameters(BuildingSO building) {
        ResourceManager.Instance.Money.Max += building.Capacity[Constant.PROPERTIES_CAPACITY_MONEY];
        ResourceManager.Instance.Faith.Max += building.Capacity[Constant.PROPERTIES_CAPACITY_FAITH];
        ResourceManager.Instance.Followers.Max += building.Capacity[Constant.PROPERTIES_CAPACITY_FOLLOWERS];
        if(this.building != null) {
            ResourceManager.Instance.Money.Max -= this.building.Capacity[Constant.PROPERTIES_CAPACITY_MONEY];
            ResourceManager.Instance.Faith.Max -= this.building.Capacity[Constant.PROPERTIES_CAPACITY_FAITH];
            ResourceManager.Instance.Followers.Max -= this.building.Capacity[Constant.PROPERTIES_CAPACITY_FOLLOWERS];
        }
    }
}
