using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject resourcesText;

    public void OnClick() {
        menu.SetActive(false);
        resourcesText.SetActive(true);
    }
}
