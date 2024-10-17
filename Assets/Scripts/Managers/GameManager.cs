using GoogleSheetLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance {
        get {
            instance = FindFirstObjectByType<GameManager>();
            return instance;
        }
    }

    private GameObject prefab;
    [SerializeField] private BuildingSO[] buildings;
    public BuildingSO[] Buildings => buildings;

    GoogleSheet buildingsData;
    const string linkToSheet = "https://sheets.googleapis.com/v4/spreadsheets/14jqLb3pwnneEam54HM05yes5jRJkelrUBzp3YRgRKA4/values/Edifici?key=AIzaSyCAqTvJSJqZE_RLfk03HQKQj2EEGjbK1Cg";

    private IEnumerator Start() {
        yield return GoogleSheetToUnity.ObtainSheetData(linkToSheet, result => { buildingsData = result; });
        SetBuildingsData();
    }

    public void SetBuildingsData() {
        foreach (BuildingSO building in buildings) {
            building.Level = 1;
            AddResources(building);
            AddCosts(building);
            AddCapacities(building);
        }
    }
    private void AddResources(BuildingSO building) {
        List<int> values = new List<int>();
        List<int> times = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_MONEY], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(Constant.PROPERTIES_MONEY, values[building.Level - 1]);
                building.Time = times[building.Level - 1];
            }
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_FAITH], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(Constant.PROPERTIES_FAITH, values[building.Level - 1]);
                building.Time = times[building.Level - 1];
            }
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_FOLLOWERS], out values)) {
            if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_TIME], out times)) {
                building.Resources.Add(Constant.PROPERTIES_FOLLOWERS, values[building.Level - 1]);
                building.Time = times[building.Level - 1];
            }
        }
    }
    private void AddCosts(BuildingSO building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_MONEY], out ints)) {
            building.Cost.Add(Constant.PROPERTIES_COST_MONEY, ints[building.Level - 1]);
        }

        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_FAITH], out ints)) {
            building.Cost.Add(Constant.PROPERTIES_COST_FAITH, ints[building.Level - 1]);
        }

        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_COST_FOLLOWERS], out ints)) {
            building.Cost.Add(Constant.PROPERTIES_COST_FOLLOWERS, ints[building.Level - 1]);
        }
    }
    private void AddCapacities(BuildingSO building) {
        List<int> ints = new List<int>();
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_MONEY], out ints)) {
            building.Capacity.Add(Constant.PROPERTIES_CAPACITY_MONEY, ints[building.Level - 1]);
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_FAITH], out ints)) {
            building.Capacity.Add(Constant.PROPERTIES_CAPACITY_FAITH, ints[building.Level - 1]);
        }
        if (GoogleSheet.TryFromStringToListInt(buildingsData[building.name, Constant.PROPERTIES_CAPACITY_FOLLOWERS], out ints)) {
            building.Capacity.Add(Constant.PROPERTIES_CAPACITY_FOLLOWERS, ints[building.Level - 1]);
        }
    }
}
