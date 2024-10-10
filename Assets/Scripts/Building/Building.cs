using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour {
    //ORDINE DI RISORSE PER IL COSTO: MONEY, FAITH, FOLLOWERS
    private List<int> costToBuild;    
    private int buildingLevel;
    private List<ResourceToGenerate> resourcesToGenerate;
    private int timeToGenerate;
    private List<int> resourcesCapacity;

    public List<int> CostToBuild { get { return costToBuild; } set { costToBuild = value; } }
    public int BuildingLevel { get { return buildingLevel; } set { buildingLevel = value; } }
    public int TimeToGenerate { get { return timeToGenerate; } set { timeToGenerate = value; } }
    public List<ResourceToGenerate> ResourcesToGenerate => resourcesToGenerate;
    public List<int> ResourcesCapacity { get { return resourcesCapacity; } set { resourcesCapacity = value; } }

    public void AddResourceToGenerate(Resource resource, int quantity) {
        ResourceToGenerate resourceToGenerate = new ResourceToGenerate(resource, quantity);
        resourcesToGenerate.Add(resourceToGenerate);
    }

    private void Start() {
        ResourceManager.Instance.Money.Max += resourcesCapacity[0];
        ResourceManager.Instance.Faith.Max += resourcesCapacity[1];
        ResourceManager.Instance.Followers.Max += resourcesCapacity[2];
    }
}
