using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    int Index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ItemBox")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.transform.GetChild(1).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
            for (int i = 1; i < 3; I++)
            {
                other.transform.GetChild(2).GetChild(i).GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            other.gameObject.GetComponent<Animator>().SetBool("Enlage", false);
            StartCoroutine(getItem());
            ItemUIAnim.SetBool("ItemIn", true);
            ItemUIScroll.SetBool("Scroll", true);

            yield return new WaitForSeconds (1);
            Other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;
            for (int i = 1; i < 3; I++)
            {
                other.transform.GetChild(2).GetChild(i).GetComponent<SkinnedMeshRenderer>().enabled = true;
            }
            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);
            other.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public IEnumerator getItem()
    {
        if (!hasItem)
        {
            Index = Random.Range(0, itemGameobjects.length);
            yourSprite.sprite = itemSprites[index];
            yield return new WaitForSeconds(4f);

            itemGameobjects[index].SetActive(true);
            hasItem = true;
        }
    }*/
}