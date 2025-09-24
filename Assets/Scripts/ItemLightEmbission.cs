using Unity.VisualScripting;
using UnityEngine;

public class ItemLightEmbission : MonoBehaviour
{
    Light itemLight;

    public GameObject player;

    public float fadeDuration = 2.0f;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float offset = 1f;
   
    void Start()
    {
        itemLight = GetComponent<Light>();
    }
    void Update()
    {
        // ºû °ü·Ã
        float t = Mathf.PingPong(Time.time / fadeDuration, 1f);
        itemLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);

        this.transform.position = transform.parent.position + (player.transform.position - transform.parent.position).normalized * offset;
    }

}
