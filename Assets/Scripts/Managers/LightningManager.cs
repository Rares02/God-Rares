using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightningManager : MonoBehaviour {

    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField] private float dayNightCycleTime;
    [SerializeField][Range(0, 180)] private float TimeOfDay;

    private void Update() {
        if (preset == null) return;

        if (Application.isPlaying) {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= dayNightCycleTime; //Clamp (0 - 24)
            UpdateLighting(TimeOfDay / dayNightCycleTime);
        }
        else {
            UpdateLighting(TimeOfDay / dayNightCycleTime);
        }
    }

    private void UpdateLighting(float timePercent) {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if (directionalLight != null) {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3(timePercent * 180f, 130, 0));
        }
    }
}
