using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceToGenerate : MonoBehaviour {
    private Resource resource;
    private int quantityToGenerate;
    private int timeToGenerate;
    public Resource Resource => resource;

    public ResourceToGenerate(Resource resource, int quantity, int time) {
        this.resource = resource;
        this.quantityToGenerate = quantity;
        this.timeToGenerate = time;
    }

}
