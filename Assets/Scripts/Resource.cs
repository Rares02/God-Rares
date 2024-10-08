using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    private float quantity;

    private void Start() {
        quantity = 0;
    }

    private void AddResource(float quantity) {
        this.quantity += quantity;
    }
    private void RemoveQuantity(float quantity) {
        this.quantity -= quantity;
    }

}
