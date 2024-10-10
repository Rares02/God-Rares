using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour {
    //ORDINE DI RISORSE PER IL COSTO: MONEY, FAITH, FOLLOWERS
    private List<int> costToBuild;    
    private int buildingLevel;
    private List<ResourceToGenerate> resourcesToGenerate;

    public List<int> CostToBuild { get { return costToBuild; } set { costToBuild = value; } }
    public int BuildingLevel { get { return buildingLevel; } set { buildingLevel = value; } }
    public List<ResourceToGenerate> ResourcesToGenerate => resourcesToGenerate;

    public void AddResourceToGenerate(Resource resource, int quantity, int time) {
        ResourceToGenerate resourceToGenerate = new ResourceToGenerate(resource, quantity, time);
        resourcesToGenerate.Add(resourceToGenerate);
    }
}
