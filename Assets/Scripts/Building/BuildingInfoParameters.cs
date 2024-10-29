using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoParameters : MonoBehaviour {
    [SerializeField] private GenericText[] names;
    [SerializeField] private GenericText[] values;
    /*[SerializeField] private GameObject[] names;
    [SerializeField] private GameObject[] names;*/
    [SerializeField] private GenericText textPrefab;

    public void SetupInfo(ExagoneCellData cellData) {
        SetFieldsInactive();
        if (cellData.CurrentBuilding.Level != 0) {
            SetLevel(cellData.CurrentBuilding.Level);
        }
        if (cellData.CurrentBuilding.Resources[ResourceType.Money] != 0) {
            SetMoney(cellData.CurrentBuilding.Resources[ResourceType.Money]);
        }
        if (cellData.CurrentBuilding.Resources[ResourceType.Faith] != 0) {
            SetFaith(cellData.CurrentBuilding.Resources[ResourceType.Faith]);
        }
        if (cellData.CurrentBuilding.Resources[ResourceType.Followers] != 0) {
            SetFollowers(cellData.CurrentBuilding.Resources[ResourceType.Followers]);
        }
        if (cellData.CurrentBuilding.Time != 0) {
            SetTime(cellData.CurrentBuilding.Time);
        }
        if (cellData.CurrentBuilding.Capacity[ResourceType.Money] != 0) {
            SetMoneyCap(cellData.CurrentBuilding.Capacity[ResourceType.Money]);
        }
        if (cellData.CurrentBuilding.Capacity[ResourceType.Faith] != 0) {
            SetFaithCap(cellData.CurrentBuilding.Capacity[ResourceType.Faith]);
        }
        if (cellData.CurrentBuilding.Capacity[ResourceType.Followers] != 0) {
            SetFollowersCap(cellData.CurrentBuilding.Capacity[ResourceType.Followers]);
        }
    }

    /*public void SetupUpgrade(ExagoneCellData cellData) {
        if (cellData.CurrentBuilding.Level != 0) {
            SetLevel(cellData.CurrentBuilding.Level);
        }
        foreach (ResourceToGenerate rtg in cellData.CurrentBuilding.Resources) {
            if (rtg.QuantityToGenerate != 0) {
                switch (rtg.Resource.Name) {
                    case Constant.PROPERTIES_MONEY:
                        SetMoney(rtg.QuantityToGenerate);
                        break;
                    case Constant.PROPERTIES_FAITH:
                        SetFaith(rtg.QuantityToGenerate);
                        break;
                    case Constant.PROPERTIES_FOLLOWERS:
                        SetFollower(rtg.QuantityToGenerate);
                        break;

                }
            }
        }
        if (cellData.CurrentBuilding.Time != 0) {
            SetTime(cellData.CurrentBuilding.Time);
        }
        if (cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_MONEY] != 0) {
            SetMoneyCap(cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_MONEY]);
        }
        if (cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_FAITH] != 0) {
            SetFaithCap(cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_FAITH]);
        }
        if (cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_FOLLOWERS] != 0) {
            SetFollowersCap(cellData.CurrentBuilding.Capacity[Constant.PROPERTIES_CAPACITY_FOLLOWERS]);
        }
    }*/

    private void SetFollowersCap(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(7);
        fields.nameField.SetText(UIText.INFO_PANEL_FOLLOWERS_CAPACITY);
        fields.nameField.SetText(value.ToString());*/
        names[7].SetText(UIText.INFO_PANEL_FOLLOWERS_CAPACITY);
        values[7].SetText(value);
        SetFieldsActive(7);
    }

    private void SetFaithCap(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(6);
        fields.nameField.SetText(UIText.INFO_PANEL_FAITH_CAPACITY);
        fields.nameField.SetText(value.ToString());*/
        names[6].SetText(UIText.INFO_PANEL_FAITH_CAPACITY);
        values[6].SetText(value);
        SetFieldsActive(6);
    }

    private void SetMoneyCap(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(5);
        fields.nameField.SetText(UIText.INFO_PANEL_MONEY_CAPACITY);
        fields.nameField.SetText(value.ToString());*/
        names[5].SetText(UIText.INFO_PANEL_MONEY_CAPACITY);
        values[5].SetText(value);
        SetFieldsActive(5);
    }

    private void SetTime(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(4);
        fields.nameField.SetText(UIText.INFO_PANEL_TIME);
        fields.nameField.SetText(value.ToString());*/
        names[4].SetText(UIText.INFO_PANEL_TIME);
        values[4].SetText(value);
        SetFieldsActive(4);
    }

    private void SetFollowers(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(3);
        fields.nameField.SetText(UIText.INFO_PANEL_FOLLOWERS);
        fields.nameField.SetText(value.ToString());*/
        names[3].SetText(UIText.INFO_PANEL_FOLLOWERS);
        values[3].SetText(value);
        SetFieldsActive(3);
    }

    private void SetFaith(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(2);
        fields.nameField.SetText(UIText.INFO_PANEL_FAITH);
        fields.nameField.SetText(value.ToString());*/
        names[2].SetText(UIText.INFO_PANEL_FAITH);
        values[2].SetText(value);
        SetFieldsActive(2);
    }

    private void SetMoney(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(1);
        fields.nameField.SetText(UIText.INFO_PANEL_MONEY);
        fields.nameField.SetText(value.ToString());*/
        names[1].SetText(UIText.INFO_PANEL_MONEY);
        values[1].SetText(value);
        SetFieldsActive(1);
    }

    private void SetLevel(int value) {
        /*(GenericText nameField, GenericText valueField) fields = InstantiateFields(0);
        fields.nameField.SetText(UIText.INFO_PANEL_LEVEL);
        fields.nameField.SetText(value.ToString());*/
        names[0].SetText(UIText.INFO_PANEL_LEVEL);
        values[0].SetText(value);
        SetFieldsActive(0);
    }

    /*private (GenericText nameField, GenericText valueField) InstantiateFields(int i) {
        GenericText nameField = Instantiate(textPrefab, columns[0].transform);
        GenericText valueField = Instantiate(textPrefab, columns[1].transform);
        return (nameField, valueField);
    }*/
    private void SetFieldsActive(int index) {
        names[index].gameObject.SetActive(true);
        values[index].gameObject.SetActive(true);
    }
    private void SetFieldsInactive() {
        for (int i = 0; i < names.Length; i++) {
            names[i].gameObject.SetActive(false);
            values[i].gameObject.SetActive(false);
        }
    }

    public void SetupEmptyInfo() {
        SetFieldsInactive();
    }
}
