using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoParameters : MonoBehaviour
{
    [SerializeField] private GameObject[] columns;
    private List<bool> fields = new List<bool>(); //lvl, money, faith, time, followers, faith cap, followers cap,
    public void SetupInfo(ExagoneCellData cellData) {
        if(cellData.CurrentBuilding.BuildingLevel != 0) {
            SetLevel();
        }
        foreach (ResourceToGenerate rtg in cellData.CurrentBuilding.ResourcesToGenerate) {
            if (rtg.QuantityToGenerate != 0) {
                switch (rtg.Resource.Name) {

                }
            } 
        }
    }

    private void SetLevel() {
        throw new NotImplementedException();
    }
}
