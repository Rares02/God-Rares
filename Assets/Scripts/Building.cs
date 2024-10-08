using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour {

    private BuildingSO building;
    private WaitForSeconds timeToGenerate;

    IEnumerator GenerateResources() {
        yield return new WaitForSeconds(building.TimeToGenerate);
    }

}
