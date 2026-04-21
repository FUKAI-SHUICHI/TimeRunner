using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static string clearTime;

    public TMP_Text timeText;


    private float time;
    private bool isPlaying = true;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            time += Time.unscaledDeltaTime;

            timeText.text = FormatTime(time);
        }
    }

    public void Goal()
    {
        isPlaying = false;
        clearTime = FormatTime(time);
        Debug.Log("クリアタイム:" + FormatTime(time));
    }

    string FormatTime(float t)
    {
        int minutes = (int)(t / 60);
        int seconds = (int)(t % 60);
        int milliseconds = (int)((t - Mathf.Floor(t)) * 100);

        return minutes.ToString("00") + ":" + 
            seconds.ToString("00") + ":" + 
            milliseconds.ToString("00");
    }
}
