using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    Resource faith;
    Resource money;
    Resource followers;

    private void Start() {
        faith = new Resource(0);
        money = new Resource(0);
        followers = new Resource(0);
    }

}
