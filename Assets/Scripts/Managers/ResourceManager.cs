using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    private static ResourceManager instance;
    public static ResourceManager Instance {
        get {
            instance = FindFirstObjectByType<ResourceManager>();
            return instance;
        }
    }

    private List<BuildingSO> houseList = new List<BuildingSO>();
    private List<BuildingSO> templeList = new List<BuildingSO>();
    private List<BuildingSO> statueList = new List<BuildingSO>();
    private List<BuildingSO> marketList = new List<BuildingSO>();

    public List<BuildingSO> HouseList { get { return houseList; } }
    public List<BuildingSO> TempleList { get { return templeList; } }
    public List<BuildingSO> StatueList { get { return statueList; } }
    public List<BuildingSO> MarketList { get { return marketList; } }

    private Resource faith;
    private Resource money;
    private Resource followers;

    public Resource Faith => faith;
    public Resource Money => money;
    public Resource Followers => followers;

    private WaitForSeconds houseTimer;
    private WaitForSeconds statueTimer;
    private WaitForSeconds templeTimer;
    private WaitForSeconds marketTimer;

    private void Start() {
        faith = new Resource("faith", 0);
        money = new Resource("money", 0);
        followers = new Resource("followers", 0);

        StartCoroutine(AddHouseResources());
        StartCoroutine(AddStatueResources());
        StartCoroutine(AddTempleResources());
        StartCoroutine(AddMarketResources());
    }

    private IEnumerator AddHouseResources() {
        while (true) {
            if(houseList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(houseList[0].Time);
                foreach (BuildingSO house in houseList) {
                    AddResources(house);                    
                }
            }
        }
    }

    private IEnumerator AddStatueResources() {
        while (true) {
            if (statueList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(statueList[0].Time);
                foreach (BuildingSO statue in statueList) {
                    AddResources(statue);
                }
            }
        }
    }
    private IEnumerator AddTempleResources() {
        while (true) {
            if (templeList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(templeList[0].Time);
                foreach (BuildingSO temple in templeList) {
                    AddResources(temple);
                }
            }
        }
    }
    private IEnumerator AddMarketResources() {
        while (true) {
            if (marketList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(marketList[0].Time);
                foreach (BuildingSO market in marketList) {
                    AddResources(market);
                }
            }
        }
    }

    private void AddResources(BuildingSO building) {
        money.AddResource(building.Resources[ResourceType.Money]);
        faith.AddResource(building.Resources[ResourceType.Faith]);
        followers.AddResource(building.Resources[ResourceType.Followers]);
    }
}
