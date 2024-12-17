using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesPanel : MonoBehaviour
{
    [SerializeField] private Image sacrifice;
    [SerializeField] private Image bless;
    [SerializeField] private Image miracle;
    [SerializeField] private Image tribute;

    private void Update() {
        //UpdateAbilities();
    }

    private void UpdateAbilities() {

        if (ResourceManager.Instance.HaveEnoughResources(GameManager.Instance.Abilities[AbilityType.Sacrifice].ResourcesToConsume)) 
            sacrifice.material.SetFloat("_BlackAndWhite", 0);
        else 
            sacrifice.material.SetFloat("_BlackAndWhite", 1);
        if (ResourceManager.Instance.HaveEnoughResources(GameManager.Instance.Abilities[AbilityType.Bless].ResourcesToConsume))
            bless.material.SetFloat("_BlackAndWhite", 0);
        else
            bless.material.SetFloat("_BlackAndWhite", 1);
        if (ResourceManager.Instance.HaveEnoughResources(GameManager.Instance.Abilities[AbilityType.MiracleOfLife].ResourcesToConsume))
            miracle.material.SetFloat("_BlackAndWhite", 0);
        else
            miracle.material.SetFloat("_BlackAndWhite", 1);
        if (ResourceManager.Instance.HaveEnoughResources(GameManager.Instance.Abilities[AbilityType.Tribute].ResourcesToConsume))
            tribute.material.SetFloat("_BlackAndWhite", 0);
        else
            tribute.material.SetFloat("_BlackAndWhite", 1);
    }

    public void ActivateAbillity(AbilityType type) {
        GameManager.Instance.Abilities[type].Activate();
    }
}