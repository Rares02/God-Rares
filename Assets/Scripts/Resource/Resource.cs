using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {
    private string name;
    private int quantity;
    private int max;
    public string Name => name; 
    public int Quantity => quantity;
    public int Max {  get => max;  set => max = value; } 
    public Resource(string name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    public void AddResource(int quantity) {
        this.quantity = Mathf.Clamp(this.quantity + quantity, 0, Max);
    }
    public void RemoveResource(int quantity) {
        this.quantity = Mathf.Clamp(this.quantity - quantity, 0, Max);
    }

}
