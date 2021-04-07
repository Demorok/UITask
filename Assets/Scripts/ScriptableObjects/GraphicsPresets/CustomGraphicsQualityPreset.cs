using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Custom Graphics Quality Preset", menuName = "Custom Graphics Quality Preset", order = 52)]
public class CustomGraphicsQualityPreset : GraphicsQualityPreset
{
    public void Set_shadowQualityValue(int shadowQualityValue)
    {
        this.shadowQualityValue = shadowQualityValue;
    }

    public void Set_shadowResolutionValue(int shadowResolutionValue)
    {
        this.shadowResolutionValue = shadowResolutionValue;
    }

    public void Set_resolutionValue(int resolutionValue)
    {
        this.resolutionValue = resolutionValue;
    }
}
