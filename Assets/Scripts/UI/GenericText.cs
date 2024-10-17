using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenericText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string newText) {
        text.text = newText;
    }
}
