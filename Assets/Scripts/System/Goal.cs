using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{

    private bool isGoal = false;
    public float waitSeconds = 3.0f;
    public GameObject clearText;

    private void OnTriggerEnter(Collider other)
    {
        
        

        if (other.CompareTag("Player") && !isGoal)
        {
            
            isGoal = true;
            GameManager.Instance.Goal();
            StartCoroutine(GoResult());

        }

        IEnumerator GoResult()
        {
            clearText.SetActive(true);
            yield return new WaitForSecondsRealtime(waitSeconds);
            SceneManager.LoadScene("ResultScene");
        }
    }
}
