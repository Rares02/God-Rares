using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgradeButton : BuildingCostButton
{
    [SerializeField] private GenericText buildingLevel;

    public void SetLevelText(int level) {
        buildingLevel.SetText(level + " => " + (level + 1));
    }

    
}
