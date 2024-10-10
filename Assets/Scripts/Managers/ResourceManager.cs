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

    private List<GameObject> housePrefabs = new List<GameObject>();
    private List<GameObject> templePrefabs = new List<GameObject>();
    private List<GameObject> statuePrefabs = new List<GameObject>();
    private List<GameObject> marketPrefabs = new List<GameObject>();

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
        while (true) {
            yield return new WaitForSeconds(housePrefabs[0].GetComponent<Building>().TimeToGenerate);
            foreach (GameObject house in housePrefabs) {
                foreach (ResourceToGenerate resourceToGenerate in house.GetComponent<Building>().ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }

    private IEnumerator AddStatueResources() {
        while (true) {
            yield return new WaitForSeconds(statuePrefabs[0].GetComponent<Building>().TimeToGenerate);
            foreach (GameObject statue in statuePrefabs) {
                foreach (ResourceToGenerate resourceToGenerate in statue.GetComponent<Building>().ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }
    private IEnumerator AddTempleResources() {
        while (true) {
            yield return new WaitForSeconds(templePrefabs[0].GetComponent<Building>().TimeToGenerate);
            foreach (GameObject temple in templePrefabs) {
                foreach (ResourceToGenerate resourceToGenerate in temple.GetComponent<Building>().ResourcesToGenerate) {
                    AddResource(resourceToGenerate);
                }
            }
        }
    }
    private IEnumerator AddMarketResources() {
        while (true) {
            yield return new WaitForSeconds(marketPrefabs[0].GetComponent<Building>().TimeToGenerate);
            foreach (GameObject market in marketPrefabs) {
                foreach (ResourceToGenerate resourceToGenerate in market.GetComponent<Building>().ResourcesToGenerate) {
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
