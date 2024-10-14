using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour {
    //ORDINE DI RISORSE PER IL COSTO: MONEY, FAITH, FOLLOWERS
    private Dictionary<string, int> costToBuild;    
    private int buildingLevel;
    private List<ResourceToGenerate> resourcesToGenerate;
    private int timeToGenerate;
    private Dictionary<string, int> resourcesCapacity;

    public Dictionary<string, int> CostToBuild { get { return costToBuild; } set { costToBuild = value; } }
    public int BuildingLevel { get { return buildingLevel; } set { buildingLevel = value; } }
    public int TimeToGenerate { get { return timeToGenerate; } set { timeToGenerate = value; } }
    public List<ResourceToGenerate> ResourcesToGenerate => resourcesToGenerate;
    public Dictionary<string, int> ResourcesCapacity { get { return resourcesCapacity; } set { resourcesCapacity = value; } }

    public void AddResourceToGenerate(Resource resource, int quantity) {
        ResourceToGenerate resourceToGenerate = new ResourceToGenerate(resource, quantity);
        resourcesToGenerate.Add(resourceToGenerate);
    }

    private void Start() {
        ResourceManager.Instance.Money.Max += resourcesCapacity[Constant.PROPERTIES_CAPACITY_MONEY];
        ResourceManager.Instance.Faith.Max += resourcesCapacity[Constant.PROPERTIES_CAPACITY_FAITH];
        ResourceManager.Instance.Followers.Max += resourcesCapacity[Constant.PROPERTIES_CAPACITY_FOLLOWERS];
    }
}
