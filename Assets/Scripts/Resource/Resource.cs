using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {
    private string name;
    private int quantity;
    private int max;
    public string Name => name; 
    public int Max {  get { return quantity; } set { quantity = value; } }

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
