using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "ScriptableObject/Ability")]
public class AbilitySO : ScriptableObject {

    //DA INSERIRE I DATI DAL GAME MANAGER!!

    [SerializeField] private AbilityType abilityType;
    private Dictionary<ResourceType, int> resourcesToConsume = new Dictionary<ResourceType, int>();
    private Dictionary<ResourceType, int> resourcesToGain = new Dictionary<ResourceType, int>();
    private float cooldown;

    public AbilityType AbilityType => abilityType;
    public Dictionary<ResourceType, int> ResourcesToConsume { get => resourcesToConsume; set => resourcesToConsume = value; }
    public Dictionary<ResourceType, int> ResourcesToGain { get => resourcesToGain; set => resourcesToGain = value; }
    public float Cooldown => cooldown;

    public void Activate() {
        if (ResourceManager.Instance.HaveEnoughResources(resourcesToConsume)) {
            RemoveResources();
            GainResources();
        }
    }

    private void RemoveResources() {
        ResourceManager.Instance.Money.RemoveResource(resourcesToConsume[ResourceType.Money]);
        ResourceManager.Instance.Faith.RemoveResource(resourcesToConsume[ResourceType.Faith]);
        ResourceManager.Instance.Followers.RemoveResource(resourcesToConsume[ResourceType.Followers]);
    }
    private void GainResources() {
        ResourceManager.Instance.Money.AddResource(resourcesToGain[ResourceType.Money]);
        ResourceManager.Instance.Faith.AddResource(resourcesToGain[ResourceType.Faith]);
        ResourceManager.Instance.Followers.AddResource(resourcesToGain[ResourceType.Followers]);
    }
}
