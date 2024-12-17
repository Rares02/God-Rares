using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIViewer : MonoBehaviour
{
    [SerializeField] private UIPanel[] panels;
    public UIPanel[] Panels => panels;
}
