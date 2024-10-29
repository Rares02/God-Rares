using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuButton : BuildingCostButton
{
    [SerializeField] private GenericText buildingName;

    public GenericText BuindingName => buildingName;
    
}
