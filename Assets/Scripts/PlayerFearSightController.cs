using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerFearSightController : MonoBehaviour
{
    public Volume globalVolume;
    private Vignette vignette;
    public PlayerFear pFear;

    public float maxVignetteIntensity = 0.6f;

    void Start()
    {
        if (globalVolume.profile.TryGet<Vignette>(out Vignette vg))
        {
            vignette = vg;
        }
        else
        {
            Debug.LogError("Vignette 효과가 Profile에 없습니다!");
        }
    }

    void Update()
    {
        if(vignette != null)
        {
            float normalizedFear = pFear.currentFearPercentage / pFear.maxFearPercentage;
            vignette.intensity.value = Mathf.Lerp(0.1f, maxVignetteIntensity, normalizedFear);
        }
    }
}
