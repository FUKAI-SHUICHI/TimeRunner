using UnityEngine;
using System.Collections;
using StarterAssets;

public class DeadArea : MonoBehaviour
{
    public Transform respawnPoint;
    public float coolTime = 3.0f;

    private bool isRespawn = false;


    public void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Player")) return;
        if (isRespawn) return;


        StartCoroutine(Respawn(other));

    }

    IEnumerator Respawn(Collider other)
     {
       isRespawn = true;

       other.gameObject.SetActive(false);

       other.transform.position =
           respawnPoint.position;

       yield return new WaitForSeconds(coolTime);

       other.gameObject.SetActive(true);

       yield return null;//1ÉtÉåÅ[ÉÄë“ã@

       StarterAssetsInputs input =
          other.GetComponent<StarterAssetsInputs>();

       if (input != null)
       {
          input.move = Vector2.zero;
          input.look = Vector2.zero;
          input.jump = false;
          input.sprint = false;
       }



        isRespawn = false;
            }        
        
}

