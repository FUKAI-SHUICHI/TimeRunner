using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class TimeController : MonoBehaviour
{

    [Header("Volume & Camera")]
    public Volume volume; // Global Volume をアサイン
    private LensDistortion lens;

    [Header("Time Settings")]
    public float slowScale = 0.2f; // スロー倍率
    public float lerpSpeed = 5f;   // 歪みやFOVの補間速度

    [Header("Visual Effects")]
    public float slowLensIntensity = -0.5f; // スロー時のLens Distortion
    public float normalLensIntensity = 0f; // 通常時のLens Distortion
    public float slowFOV = 80f;            // スロー時のカメラFOV
    public float normalFOV = 60f;          // 通常時のカメラFOV
    

    private ColorAdjustments colorAdjustments;
    private StarterAssetsInputs input;
    private Camera mainCam;

    void Start()
    {
        input = FindFirstObjectByType<StarterAssetsInputs>();



        if (volume != null && volume.profile.TryGet(out lens))
        {
            lens.intensity.overrideState = true;
        }
        else
        {
            Debug.LogWarning("Lens Distortion が Volume Profile にありません！");
        }

        mainCam = Camera.main;
        if (mainCam != null)
        {
            // Main Camera の Post Processing を強制ON
            var urpCam = mainCam.GetComponent<UniversalAdditionalCameraData>();
            if (urpCam != null)
                urpCam.renderPostProcessing = true;
        }

        if (volume.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.colorFilter.overrideState = true;
            colorAdjustments.contrast.overrideState = true;
        }
        else
        {
            Debug.LogWarning("Color Adjustments が Volume Profile にありません！");
        }


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

        // スロー中かどうかで目標値を切り替え
        float targetLens = input.timeSlow ? slowLensIntensity : normalLensIntensity;
        float targetFOV = input.timeSlow ? slowFOV : normalFOV;

        // Lens Distortion の補間
        if (lens != null)
        {
            lens.intensity.value = Mathf.Lerp(lens.intensity.value, targetLens, Time.unscaledDeltaTime * lerpSpeed);
        }

        // FOV の補間
        if (mainCam != null)
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, targetFOV, Time.unscaledDeltaTime * lerpSpeed);
        }

        

        Color targetColor = input.timeSlow ? new Color(0.85f, 0.9f, 1f) : Color.white;

        colorAdjustments.colorFilter.value = Color.Lerp(
            colorAdjustments.colorFilter.value,
            targetColor,
            Time.unscaledDeltaTime * 5f
        );

        float targetExposure = input.timeSlow ? 0.5f : 0f;

        colorAdjustments.postExposure.value = Mathf.Lerp(
            colorAdjustments.postExposure.value,
            targetExposure,
            Time.unscaledDeltaTime * 5f
        );

        float targetContrast = input.timeSlow ? -10f : 0f;

        colorAdjustments.contrast.value = Mathf.Lerp(
            colorAdjustments.contrast.value,
            targetContrast,
            Time.unscaledDeltaTime * 5f
        );
    }
}