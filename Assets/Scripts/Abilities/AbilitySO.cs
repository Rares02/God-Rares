using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "ScriptableObject/Ability")]
public class AbilitySO : ScriptableObject {

    //DA INSERIRE I DATI DAL GAME MANAGER!!

    private string abilityName;
    private Dictionary<string, int> resourcesToConsume;
    private Dictionary<string, int> resourcesToGain;

    public string AbilityName { get =>  abilityName; set => abilityName = value; }
    public Dictionary<string, int> ResourcesToConsume { get => resourcesToConsume; set => resourcesToConsume = value; }
    public Dictionary<string, int> ResourcesToGain { get => resourcesToGain; set => resourcesToGain = value; }

    public void Activate() {
        RemoveResources();
        GainResources();
    }

    private void RemoveResources() {
        ResourceManager.Instance.Money.RemoveQuantity(resourcesToConsume["Money Lost"]);
        ResourceManager.Instance.Faith.RemoveQuantity(resourcesToConsume["Faith Lost"]);
        ResourceManager.Instance.Followers.RemoveQuantity(resourcesToConsume["Followers Lost"]);
    }
    private void GainResources() {
        ResourceManager.Instance.Money.AddResource(resourcesToGain["Money Received"]);
        ResourceManager.Instance.Faith.AddResource(resourcesToGain["Faith Received"]);
        ResourceManager.Instance.Followers.AddResource(resourcesToGain["Followers Received"]);
    }
}
