using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Building")]
public class BuildingSO : ScriptableObject {

    //Resource resourceToGenerate
    [SerializeField] private float amountToGenerate;
    [SerializeField] private float timeToGenerate;
    public float AmountToGenerate => amountToGenerate;
    public float TimeToGenerate => timeToGenerate;

}
