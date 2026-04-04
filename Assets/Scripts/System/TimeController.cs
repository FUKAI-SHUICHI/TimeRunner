using StarterAssets;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowScale = 0.2f;

    private StarterAssets.StarterAssetsInputs input;

    void Start()
    {
        input = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update()
    {
        if (input.timeSlow)
        {
            Time.timeScale = slowScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}