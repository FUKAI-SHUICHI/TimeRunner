using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("MainStage");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
