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

    public List<Building> HouseList {  get { return houseList; } }
    public List<Building> TempleList { get { return templeList; } }
    public List<Building> StatueList { get { return statueList; } }
    public List<Building> MarketList { get { return marketList; } }

    private Resource faith;
    private Resource money;
    private Resource followers;

    public Resource Faith => faith;
    public Resource Money => money;
    public Resource Followers => followers;

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
        while (true && houseList.Count > 0) {
            yield return new WaitForSeconds(houseList[0].TimeToGenerate);
            foreach (Building house in houseList) {
                foreach (ResourceToGenerate resourceToGenerate in house.ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }

    private IEnumerator AddStatueResources() {
        while (true && statueList.Count > 0) {
            yield return new WaitForSeconds(statueList[0].TimeToGenerate);
            foreach (Building statue in statueList) {
                foreach (ResourceToGenerate resourceToGenerate in statue.ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }
    private IEnumerator AddTempleResources() {
        while (true && templeList.Count > 0) {
            yield return new WaitForSeconds(templeList[0].TimeToGenerate);
            foreach (Building temple in templeList) {
                foreach (ResourceToGenerate resourceToGenerate in temple.ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }
    private IEnumerator AddMarketResources() {
        while (true && marketList.Count > 0) {
            yield return new WaitForSeconds(marketList[0].TimeToGenerate);
            foreach (Building market in marketList) {
                foreach (ResourceToGenerate resourceToGenerate in market.ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
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
