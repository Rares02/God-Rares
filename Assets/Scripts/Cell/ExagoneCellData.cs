using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExagoneCellData {
    private Building building;
    private TerrainType terrainType;
    public Building CurrentBuilding => building;

    public void SetBuilding(Building building) {
        this.building = building;
    }
}
