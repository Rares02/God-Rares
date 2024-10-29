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
    private List<BuildingSO> godRaresList = new List<BuildingSO>();

    public List<BuildingSO> HouseList { get { return houseList; } }
    public List<BuildingSO> TempleList { get { return templeList; } }
    public List<BuildingSO> StatueList { get { return statueList; } }
    public List<BuildingSO> MarketList { get { return marketList; } }
    public List<BuildingSO> GodRaresList { get { return godRaresList; } }

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
    private WaitForSeconds godRaresTimer;

    private void Start() {
        faith = new Resource("faith", 0);
        money = new Resource("money", 0);
        followers = new Resource("followers", 0);

        StartCoroutine(AddHouseResources());
        StartCoroutine(AddStatueResources());
        StartCoroutine(AddTempleResources());
        StartCoroutine(AddMarketResources());
        StartCoroutine(AddGodRaresResources());
    }

    private IEnumerator AddHouseResources() {
        while (true) {
            if(houseList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(houseList[0].Time);
                foreach (BuildingSO house in houseList) {
                    AddResources(house.Resources);                    
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
                    AddResources(statue.Resources);
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
                    AddResources(temple.Resources);
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
                    AddResources(market.Resources);
                }
            }
        }
    }
    private IEnumerator AddGodRaresResources() {
        while (true) {
            if (godRaresList.Count == 0) {
                yield return new WaitForFixedUpdate();
            }
            else {
                yield return new WaitForSeconds(godRaresList[0].Time);
                foreach (BuildingSO godRares in godRaresList) {
                    AddResources(godRares.Resources);
                }
            }
        }
    }

    public void AddResources(Dictionary<ResourceType, int> resources) {
        money.AddResource(resources[ResourceType.Money]);
        faith.AddResource(resources[ResourceType.Faith]);
        followers.AddResource(resources[ResourceType.Followers]);
    }
    public void RemoveResources(Dictionary<ResourceType, int> resources) {
        money.RemoveResource(resources[ResourceType.Money]);
        faith.RemoveResource(resources[ResourceType.Faith]);
        followers.RemoveResource(resources[ResourceType.Followers]);
    }

    public bool HaveEnoughResources(Dictionary<ResourceType, int> resources) {
        return money.Quantity >= resources[ResourceType.Money] && 
            faith.Quantity >= resources[ResourceType.Faith] && 
            followers.Quantity >= resources[ResourceType.Followers];
    }
}
