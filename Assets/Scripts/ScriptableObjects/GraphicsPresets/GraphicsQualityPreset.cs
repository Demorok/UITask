using UnityEngine;

[CreateAssetMenu(fileName = "new Graphics Quality Preset", menuName = "Graphics Quality Preset", order = 51)]
public class GraphicsQualityPreset : ScriptableObject
{
    [SerializeField]
    protected string presetName;
    [SerializeField]
    protected int shadowQualityValue;
    [SerializeField]
    protected int shadowResolutionValue;
    [SerializeField]
    protected int resolutionValue;

    public string Get_presetName()
    {
        return presetName;
    }

    public int Get_shadowQualityValue()
    {
        return shadowQualityValue;
    }

    public int Get_shadowResolutionValue()
    {
        return shadowResolutionValue;
    }

    public int Get_resolutionValue()
    {
        return resolutionValue;
    }
}
