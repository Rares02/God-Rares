using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour {
    private Resource resourceToGenerate;
    private float amountToGenerate;
    private float timeToGenerate;
    private float costToBuild;

    public Resource ResourceToGenerate => resourceToGenerate;
    public float AmountToGenerate => amountToGenerate;
    public float TimeToGenerate => timeToGenerate;

    IEnumerator GenerateResources() {
        yield return new WaitForSeconds(timeToGenerate);
        resourceToGenerate.AddResource(amountToGenerate);
    }

}
