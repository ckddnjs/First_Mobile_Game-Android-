using System.Collections;
using UnityEngine;

public class EndingBrightness : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color baseColor = Color.yellow;
    public float minEmission = 0f;
    public float maxEmission = 2f;
    public float flickerSpeed = 0.5f;

    Material mat;

    void Start()
    {
        mat = targetRenderer.material;
        StartCoroutine(Flicker());
    }

    void Update()
    {
        
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float emission = Mathf.Lerp(minEmission, maxEmission, Mathf.PingPong(Time.time * flickerSpeed, 1));
            mat.SetColor("_EmissionColor", baseColor * emission);
            yield return null;
        }
    }
}
