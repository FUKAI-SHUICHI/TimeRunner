using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Goal();

        if (other.CompareTag("Player"))
        {
            Debug.Log("Goal!!");

        }
    }
}
