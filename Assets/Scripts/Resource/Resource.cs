using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

    private int quantity;

    public Resource(int quantity) {
        this.quantity = quantity;
    }

    public void AddResource(int quantity) {
        this.quantity += quantity;
    }
    public void RemoveQuantity(int quantity) {
        this.quantity -= quantity;
    }

}
