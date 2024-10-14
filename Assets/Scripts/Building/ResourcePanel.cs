using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI faithText;
    [SerializeField] private TextMeshProUGUI followersText;

    private void Update() {
        UpdateResourcesValues();
    }

    private void UpdateResourcesValues() {
        moneyText.text = $"{ResourceManager.Instance.Money.Quantity} / {ResourceManager.Instance.Money.Max}";
        faithText.text = $"{ResourceManager.Instance.Faith.Quantity} / {ResourceManager.Instance.Faith.Max}";
        followersText.text = $"{ResourceManager.Instance.Followers.Quantity} / {ResourceManager.Instance.Followers.Max}";
    }
}
