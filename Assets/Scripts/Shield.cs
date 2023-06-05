using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    
    bool hasShield = false;
    [Tooltip("The number of seconds that the shield remains active")][SerializeField] float duration = 5;


    //The first player to take it is protected.
    bool shieldPickedUp = false;
   


    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    // All players can call this function; only the StateAuthority receives the call.


    public bool ShieldActive()
    {

        return hasShield;
    }


   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield") && !shieldPickedUp)
        {

            Debug.Log("Player got shiel");
            hasShield = true;
            shieldPickedUp = true;

            StartCoroutine(ShieldTemporarily());
            Destroy(other.gameObject);
        }
    }


    private IEnumerator ShieldTemporarily()
    {   // co-routines
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        Debug.Log("Shield gone!");
        hasShield = false;
        shieldPickedUp = false;

    }
}
