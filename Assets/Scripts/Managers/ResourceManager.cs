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

    private List<Building> houseList = new List<Building>();
    private List<Building> templeList = new List<Building>();
    private List<Building> statueList = new List<Building>();
    private List<Building> marketList = new List<Building>();

    public List<Building> HouseList { get { return houseList; } }
    public List<Building> TempleList { get { return templeList; } }
    public List<Building> StatueList { get { return statueList; } }
    public List<Building> MarketList { get { return marketList; } }

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
                yield return new WaitForSeconds(houseList[0].TimeToGenerate);
                foreach (Building house in houseList) {
                    foreach (ResourceToGenerate resourceToGenerate in house.ResourcesToGenerate) {
                        AddResource(resourceToGenerate);
                        Debug.Log("UPDATED RESOURCES BY HOUSES: \n" +
                            "money: " + money.Quantity + "\n" +
                            "faith: " + faith.Quantity + "\n" +
                            "followers: " + followers.Quantity + "\n" +
                            "MAX RESOURCES: \n" +
                            "money: " + money.Max + "\n" +
                            "faith: " + faith.Max + "\n" +
                            "followers: " + followers.Max + "\n");
                    }
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
                yield return new WaitForSeconds(statueList[0].TimeToGenerate);
                foreach (Building statue in statueList) {
                    foreach (ResourceToGenerate resourceToGenerate in statue.ResourcesToGenerate) {
                        AddResource(resourceToGenerate);
                        Debug.Log("UPDATED RESOURCES BY STATUES: \n" +
                            "money: " + money.Quantity + "\n" +
                            "faith: " + faith.Quantity + "\n" +
                            "followers: " + followers.Quantity + "\n" +
                            "MAX RESOURCES: \n" +
                            "money: " + money.Max + "\n" +
                            "faith: " + faith.Max + "\n" +
                            "followers: " + followers.Max + "\n");
                    }
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
                yield return new WaitForSeconds(templeList[0].TimeToGenerate);
                foreach (Building temple in templeList) {
                    foreach (ResourceToGenerate resourceToGenerate in temple.ResourcesToGenerate) {
                        AddResource(resourceToGenerate);
                        Debug.Log("UPDATED RESOURCES BY TEMPLES: \n" +
                            "money: " + money.Quantity + "\n" +
                            "faith: " + faith.Quantity + "\n" +
                            "followers: " + followers.Quantity + "\n" +
                            "MAX RESOURCES: \n" +
                            "money: " + money.Max + "\n" +
                            "faith: " + faith.Max + "\n" +
                            "followers: " + followers.Max + "\n");
                    }
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
                yield return new WaitForSeconds(marketList[0].TimeToGenerate);
                foreach (Building market in marketList) {
                    foreach (ResourceToGenerate resourceToGenerate in market.ResourcesToGenerate) {
                        AddResource(resourceToGenerate);
                        Debug.Log("UPDATED RESOURCES BY MARKETS: \n" +
                            "money: " + money.Quantity + "\n" +
                            "faith: " + faith.Quantity + "\n" +
                            "followers: " + followers.Quantity + "\n" +
                            "MAX RESOURCES: \n" +
                            "money: " + money.Max + "\n" +
                            "faith: " + faith.Max + "\n" +
                            "followers: " + followers.Max + "\n");
                    }
                }
            }
        }
    }

    private void AddResource(ResourceToGenerate resourceToGenerate) {
        if (resourceToGenerate.Resource.Name.ToLower().Equals(faith.Name)) {
            faith.AddResource(resourceToGenerate.QuantityToGenerate);
        }
        else if (resourceToGenerate.Resource.Name.ToLower().Equals(money.Name)) {
            money.AddResource(resourceToGenerate.QuantityToGenerate);
        }
        else if (resourceToGenerate.Resource.Name.ToLower().Equals(followers.Name)) {
            followers.AddResource(resourceToGenerate.QuantityToGenerate);
        }
    }
}
