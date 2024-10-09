using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    private float quantity;

    public Resource(float quantity) {
        this.quantity = quantity;
    }

    public void AddResource(float quantity) {
        this.quantity += quantity;
    }
    public void RemoveQuantity(float quantity) {
        this.quantity -= quantity;
    }

}
