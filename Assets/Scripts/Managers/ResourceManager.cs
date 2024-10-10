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
    public Resource money;
    private Resource followers;

    private void Start() {
        faith = new Resource(0);
        money = new Resource(0);
        followers = new Resource(0);

        StartCoroutine(AddHouseResources());
        StartCoroutine(AddStatueResources());
        StartCoroutine(AddTempleResources());
        StartCoroutine(AddMarketResources());
    }

    private IEnumerator AddHouseResources() {
        while (true) {
            yield return new WaitForSeconds(5);
            foreach (GameObject house in housePrefabs) {
                //money.AddResource(house.GetComponent<Building>().AmountToGenerate);
            }
        }
    }
    private IEnumerator AddStatueResources() {
        while (true) {
            yield return new WaitForSeconds(5);
            foreach (GameObject house in housePrefabs) {
                //money.AddResource(house.GetComponent<Building>().AmountToGenerate);
            }
        }
    }
    private IEnumerator AddTempleResources() {
        while (true) {
            yield return new WaitForSeconds(5);
            foreach (GameObject house in housePrefabs) {
                //money.AddResource(house.GetComponent<Building>().AmountToGenerate);
            }
        }
    }
    private IEnumerator AddMarketResources() {
        while (true) {
            yield return new WaitForSeconds(5);
            foreach (GameObject house in housePrefabs) {
                //money.AddResource(house.GetComponent<Building>().AmountToGenerate);
            }
        }
    }

}
