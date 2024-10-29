using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBuilding", menuName = "ScriptableObject/Building")]
public class BuildingSO : ScriptableObject {
    //ORDINE DI RISORSE PER IL COSTO: MONEY, FAITH, FOLLOWERS
    [SerializeField] private BuildingType buildingType;
    [SerializeField] private GameObject model;
    [SerializeField] private bool isBuyable;

    private string buildingName;
    private int level;

    private Dictionary<ResourceType, int> cost = new Dictionary<ResourceType, int>();
    private Dictionary<ResourceType, int> refund = new Dictionary<ResourceType, int>();
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    private int time;
    private int buildingTime;
    private Dictionary<ResourceType, int> capacity = new Dictionary<ResourceType, int>();

    public string Name { get => buildingName; set => buildingName = value; }
    public bool IsBuyable => isBuyable;
    public BuildingType BuildingType => buildingType;
    public GameObject Model => model;
    public Dictionary<ResourceType, int> Cost { get => cost; set => cost = value; }
    public Dictionary<ResourceType, int> Refund { get => refund; set => refund = value; }
    public int Level { get => level; set => level = value; } 
    public int Time { get => time; set => time = value; } 
    public Dictionary<ResourceType, int> Resources { get => resources; set => resources = value; }
    public Dictionary<ResourceType, int> Capacity { get => capacity; set => capacity = value; }
    public int BuildingTime { get => buildingTime; set => buildingTime = value; }

    public int MaxLevel => resources.Count - 1;
}
