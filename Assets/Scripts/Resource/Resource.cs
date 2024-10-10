using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {
    private string name;
    private int quantity;

    public Resource(string name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    public void AddResource(int quantity) {
        this.quantity += quantity;
    }
    public void RemoveQuantity(int quantity) {
        this.quantity -= quantity;
    }

}
