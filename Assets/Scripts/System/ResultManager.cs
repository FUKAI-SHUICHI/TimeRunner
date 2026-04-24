using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManger : MonoBehaviour
{
    public TMP_Text resultText;

    void Start()
    {
        resultText.text ="Goal!!\n" +  "ClearTime : " + GameManager.clearTime + "\n" + "BestTime : " + GameManager.bestTime + "\n";

        if (GameManager.isNewRecord)
        {
            resultText.text += "NEW RECORD!!";
        }

    }

    public void Retry()
    {

        SceneManager.LoadScene("MainStage");

    }

    public void ExitTitle()
    {
        SceneManager.LoadScene("TitleScene");

    }
}
