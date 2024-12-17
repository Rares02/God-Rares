using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private GenericText moneyText;
    [SerializeField] private GenericText faithText;
    [SerializeField] private GenericText followersText;

    [SerializeField] private GameObject endScreen;

    private void Update() {
        UpdateResourcesValues();
        if(ResourceManager.Instance.Followers.Quantity > 5000) {
            endScreen.SetActive(true);
        }
    }

    private void UpdateResourcesValues() {
        moneyText.SetText($"{ResourceManager.Instance.Money.Quantity} / {ResourceManager.Instance.Money.Max}");
        faithText.SetText($"{ResourceManager.Instance.Faith.Quantity} / {ResourceManager.Instance.Faith.Max}");
        followersText.SetText($"{ResourceManager.Instance.Followers.Quantity} / {ResourceManager.Instance.Followers.Max}");
    }
}
