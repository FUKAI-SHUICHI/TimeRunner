using UnityEngine;
using TMPro;

public class ResultManger : MonoBehaviour
{
    public TMP_Text resultText;
    void Start()
    {
        resultText.text ="Goal!!\n" +  "ClearTime: " + GameManager.clearTime;
    }

}
