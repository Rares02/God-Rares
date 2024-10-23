using GoogleSheetLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private CellManager cellManager;

    private static GameManager instance;
    public static GameManager Instance {
        get {
            instance = FindFirstObjectByType<GameManager>();
            return instance;
        }
    }

    private GameObject prefab;

    [SerializeField] private Buildings buildings;
    public Buildings Buildings => buildings;

    GoogleSheet buildingsData;
    const string linkToSheet = "https://sheets.googleapis.com/v4/spreadsheets/14jqLb3pwnneEam54HM05yes5jRJkelrUBzp3YRgRKA4/values/Edifici?key=AIzaSyCAqTvJSJqZE_RLfk03HQKQj2EEGjbK1Cg";

    private IEnumerator Start() {
        yield return GoogleSheetToUnity.ObtainSheetData(linkToSheet, result => { buildingsData = result; });
        SetBuildingsData();
        cellManager.Initialize();
    }

    public void SetBuildingsData() {
        foreach (BuildingSOType buildingType in buildings.BuildingTypes) {
            int level = 1;
            foreach (BuildingSO building in buildingType.BuildingsLevels) {
                building.Level = level;
                AddResources(building);
                AddCosts(building);
                AddCapacities(building);
                level++;
            }
        }
    }
    private void AddResources(BuildingSO building) {
        List<int> values = new List<int>();
        List<int> times = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_MONEY], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(ResourceType.Money, values[building.Level - 1]);
                building.Time = times[0];  //[building.Level - 1];
            }
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_FAITH], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(ResourceType.Faith, values[building.Level - 1]);
                building.Time = times[0];  //[building.Level - 1];
            }
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_FOLLOWERS], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(ResourceType.Followers, values[building.Level - 1]);
                building.Time = times[0];  //[building.Level - 1];
            }
        }
    }
    private void AddCosts(BuildingSO building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_COST_MONEY], out ints)) {
            building.Cost.Add(ResourceType.Money, ints[building.Level - 1]);
        }

        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_COST_FAITH], out ints)) {
            building.Cost.Add(ResourceType.Faith, ints[building.Level - 1]);
        }

        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_COST_FOLLOWERS], out ints)) {
            building.Cost.Add(ResourceType.Followers, ints[building.Level - 1]);
        }
    }
    private void AddCapacities(BuildingSO building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_CAPACITY_MONEY], out ints)) {
            building.Capacity.Add(ResourceType.Money, ints[building.Level - 1]);
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_CAPACITY_FAITH], out ints)) {
            building.Capacity.Add(ResourceType.Faith, ints[building.Level - 1]);
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.BuildingType.ToString(), Constant.PROPERTIES_CAPACITY_FOLLOWERS], out ints)) {
            building.Capacity.Add(ResourceType.Followers, ints[building.Level - 1]);
        }
    }

    public BuildingSO GetNexLevel(BuildingSO building) {
        if (buildings[building.BuildingType].BuildingsLevels.Count > building.Level)
            return buildings[building.BuildingType].BuildingsLevels[building.Level];
        return null;
    }

    private void GetValueByLevel(List<int> list, int level) {
        if (list.Count < level) {

        }
    }
}

[System.Serializable]
public class BuildingSOType {
    [SerializeField] List<BuildingSO> buildingLevels;

    public List<BuildingSO> BuildingsLevels => buildingLevels;

    public BuildingType Type => buildingLevels[0].BuildingType;
}
[System.Serializable]
public class Buildings {
    [SerializeField] List<BuildingSOType> buildingTypes;

    public List<BuildingSOType> BuildingTypes => buildingTypes;

    public BuildingSOType this[BuildingType type] {
        get {
            foreach (BuildingSOType buildingType in buildingTypes) {
                if (buildingType.Type == type) {
                    return buildingType;
                }
            }
            return null;
        }
    }
}
