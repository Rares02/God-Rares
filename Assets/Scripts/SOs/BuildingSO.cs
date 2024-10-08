using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Building")]
public class BuildingSO : ScriptableObject {

    private Resource resourceToGenerate;
    [SerializeField] private float amountToGenerate;
    [SerializeField] private float timeToGenerate;
    [SerializeField] private float costToBuild;
    
    public Resource ResourceToGenerate => resourceToGenerate;
    public float AmountToGenerate => amountToGenerate;
    public float TimeToGenerate => timeToGenerate;
}
