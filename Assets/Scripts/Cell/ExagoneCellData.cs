using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExagoneCellData {
    [SerializeField] private Building building;
    [SerializeField] private TerrainType terrainType;
    [SerializeField] private bool isRemovable;
    public Building CurrentBuilding => building;
    public TerrainType TerrainType => terrainType;
    public bool IsRemovable => isRemovable;

    public void SetBuilding(Building building) {
        this.building = building;
    }
}
