using UnityEngine;

public enum FearState
{
    Comfortable,
    Fear1,
    Fear2,
    Fear3
}

public class PlayerFear : MonoBehaviour
{
    public float currentFearPercentage = 0;
    public float maxFearPercentage = 100;
    public float fearIncreaseRate = 2.0f;

    public FearState currentFearState;
    public FearState preFearState;

    void Start()
    {
        currentFearPercentage = 0;
        currentFearState = FearState.Comfortable;
        preFearState = currentFearState;
    }

    void Update()
    {

        if (currentFearPercentage < maxFearPercentage)
        {
            currentFearPercentage += fearIncreaseRate * Time.deltaTime;
        }
        currentFearPercentage = Mathf.Clamp(currentFearPercentage, 0, maxFearPercentage);

        if (currentFearPercentage < 15)
        {
            currentFearState = FearState.Comfortable;
        }
        else if (currentFearPercentage < 40)
        {
            currentFearState = FearState.Fear1;
        }
        else if (currentFearPercentage < 85)
        {
            currentFearState = FearState.Fear2;
        }
        else
        {
            currentFearState = FearState.Fear3;
        }
    }
}
