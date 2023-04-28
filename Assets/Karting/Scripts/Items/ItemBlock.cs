using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
   public GameObject[] allLights;
   public static int currentLight = 1;

   private void OnTriggerEnter(Collider other) 
   {
        
        if(other.tag == "Player")
        {
            allLights[currentLight].SetActive(false);
            currentLight = currentLight % allLights.Length;

            StartCoroutine(WaitSeconds());
            
            KartItem currentItem = other.GetComponent<KartItem>();

            if(currentItem != null) { 
                if(currentItem.HeldItem == -1 && currentItem.CanPickup)
                {
                other.GetComponent<KartItem>().StartPickup();
                }
            }
        }

    IEnumerator WaitSeconds()
    {
        allLights[currentLight].SetActive(true);
        
        yield return new WaitForSeconds(3);

        allLights[currentLight].SetActive(false);
    }

   }

}