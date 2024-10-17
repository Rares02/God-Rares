using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBuilding", menuName = "ScriptableObject/Building")]
public class BuildingSO : ScriptableObject {
    //ORDINE DI RISORSE PER IL COSTO: MONEY, FAITH, FOLLOWERS
    private string buildingName;
    [SerializeField] private GameObject model;

    private int level;
    private Dictionary<string, int> cost = new Dictionary<string, int>();    
    private Dictionary<string, int> resources = new Dictionary<string, int>();
    private int time;
    private int buildingTime;
    private Dictionary<string, int> capacity = new Dictionary<string, int>();

    public GameObject Model => model;
    public Dictionary<string, int> Cost { get => cost; set => cost = value; } 
    public int Level { get => level; set => level = value; } 
    public int Time { get => time; set => time = value; } 
    public Dictionary<string, int> Resources { get => resources; set => resources = value; }
    public Dictionary<string, int> Capacity { get => capacity; set => capacity = value; }
    public int BuildingTime { get => buildingTime; set => buildingTime = value; }
}
