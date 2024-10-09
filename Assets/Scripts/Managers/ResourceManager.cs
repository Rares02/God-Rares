using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour { 

    private Resource faith;
    private Resource money;
    private Resource followers;

    private void Start() {
        faith = new Resource(0);
        money = new Resource(0);
        followers = new Resource(0);
    }

}
