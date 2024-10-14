using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceToGenerate {
    private Resource resource;
    private int quantityToGenerate;

    public Resource Resource => resource;
    public int QuantityToGenerate => quantityToGenerate;

    public ResourceToGenerate(Resource resource, int quantity) {
        this.resource = resource;
        quantityToGenerate = quantity;
    }

}
