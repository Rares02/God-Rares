using GoogleSheetLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameObject prefab;
    private Building building;

    GoogleSheet buildingsData;
    const string linkToSheet = "https://sheets.googleapis.com/v4/spreadsheets/14jqLb3pwnneEam54HM05yes5jRJkelrUBzp3YRgRKA4/values/Edifici?key=AIzaSyCAqTvJSJqZE_RLfk03HQKQj2EEGjbK1Cg";

    private IEnumerator Start() {
        yield return GoogleSheetToUnity.ObtainSheetData(linkToSheet, result => { buildingsData = result; });
    }

    private void SetBuildingsData() {
        SetHouseData();
        SetTempleData();
        SetStatueData();
        SetMarketData();
    }
    private void SetHouseData() {
        prefab = (GameObject)Resources.Load("Prefabs/House");
        building = prefab.GetComponent<Building>();
        building.BuildingLevel = 1;

        AddResourcesToGenerate(building);
        AddCosts(building);
        

        List<int> ints3 = new List<int>();
        List<int> ints4 = new List<int>();
        List<int> ints5 = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[prefab.name, "cost money"], out ints3)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData["house", "cost faith"], out ints4)) {
                if (GoogleSheet.TryFromStringToListInt(buildingsData["house", "cost faithful"], out ints5)) {
                    building.CostToBuild.Add(ints3[building.BuildingLevel]);
                    building.CostToBuild.Add(ints4[building.BuildingLevel]);
                    building.CostToBuild.Add(ints5[building.BuildingLevel]);
                }
            }
        }

    }
    private void SetTempleData() {
        prefab = (GameObject)Resources.Load("Prefabs/Temple");
        building = prefab.GetComponent<Building>();
        building.BuildingLevel = 1;
    }
    private void SetStatueData() {
        prefab = (GameObject)Resources.Load("Prefabs/Statue");
        building = prefab.GetComponent<Building>();
        building.BuildingLevel = 1;
    }
    private void SetMarketData() {
        prefab = (GameObject)Resources.Load("Prefabs/Market");
        building = prefab.GetComponent<Building>();
        building.BuildingLevel = 1;
    }
    private void AddResourcesToGenerate(Building building) {
        List<int> ints = new List<int>();
        List<int> ints2 = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, "money for s"], out ints)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, "profit time"], out ints2)) {
                if (ints[building.BuildingLevel] - 1 != 0) {
                    building.AddResourceToGenerate(ResourceManager.Instance.money, ints[building.BuildingLevel], ints2[building.BuildingLevel]);
                }
            }
        }
    }

}
