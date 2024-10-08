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
        prefab = (GameObject)Resources.Load(Constant.HOUSE_PREFAB_PATH);
        building = prefab.GetComponent<Building>();

        building.BuildingLevel = 1;
        AddResourcesToGenerate(building);
        AddCosts(building);
        AddCapacities(building);
    }
    private void SetTempleData() {
        prefab = (GameObject)Resources.Load(Constant.TEMPLE_PREFAB_PATH);
        building = prefab.GetComponent<Building>();

        building.BuildingLevel = 1;
        AddResourcesToGenerate(building);
        AddCosts(building);
    }
    private void SetStatueData() {
        prefab = (GameObject)Resources.Load(Constant.STATUE_PREFAB_PATH);
        building = prefab.GetComponent<Building>();

        building.BuildingLevel = 1;
        AddResourcesToGenerate(building);
        AddCosts(building);
    }
    private void SetMarketData() {
        prefab = (GameObject)Resources.Load(Constant.MARKET_PREFAB_PATH);
        building = prefab.GetComponent<Building>();

        building.BuildingLevel = 1;
        AddResourcesToGenerate(building);
        AddCosts(building);
    }

    private void AddResourcesToGenerate(Building building) {
        List<int> ints = new List<int>();
        List<int> ints2 = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_MONEY], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out ints2)) {
                    building.AddResourceToGenerate(ResourceManager.Instance.Money, ints[building.BuildingLevel]);
                }
            }
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_FAITH], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out ints2)) {
                    building.AddResourceToGenerate(ResourceManager.Instance.Faith, ints[building.BuildingLevel]);
                }
            }
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_FOLLOWERS], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out ints2)) {
                    building.AddResourceToGenerate(ResourceManager.Instance.Followers, ints[building.BuildingLevel]);
                }
            }
        }
    }
    private void AddCosts(Building building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_MONEY], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                building.CostToBuild.Add(ints[building.BuildingLevel]);
            }
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_FAITH], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                building.CostToBuild.Add(ints[building.BuildingLevel]);
            }
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_FOLLOWERS], out ints)) {
            if (ints[building.BuildingLevel] != 0) {
                building.CostToBuild.Add(ints[building.BuildingLevel]);
            }
        }
    }
    private void AddCapacities(Building building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_MONEY], out ints)) {
            building.ResourcesCapacity.Add(ints[building.BuildingLevel]);
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_FAITH], out ints)) {
            building.ResourcesCapacity.Add(ints[building.BuildingLevel]);
        }
        else if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_FOLLOWERS], out ints)) {
            building.ResourcesCapacity.Add(ints[building.BuildingLevel]);
        }
    }
}
