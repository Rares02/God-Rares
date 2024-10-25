using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLightingPreset", menuName = "ScriptableObject/Lighting")]
public class LightingPreset : ScriptableObject {
    public Gradient ambientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}
