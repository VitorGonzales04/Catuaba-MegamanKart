using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    private static GuiManager instance;

    public static GuiManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GuiManager>();
            }
            return instance;
        }
    }

    private Image itemImage;

    [SerializeField]
    Sprite[] itemSprites;
    private Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeItem(string item)
    {
        if (itemImage)
            StartCoroutine(ItemImageCoroutine(GameManager.Instance.GetItemIndex(item)));
    }

    IEnumerator ItemImageCoroutine (int index)
    {
        if (itemImage == null)
            yield break;
        if(index == -1)
        {
            itemImage.sprite = defaultSprite;
            yield break;
        }

        int count = 20;
        float time = 1;
        for(int i = 0; i < count; i++)
        {
            if (itemImage == null)
                yield break;
            itemImage.sprite = itemSprites[i % itemSprites.Length];
            yield return new WaitForSeconds((time / count) * 2);
        }
        for(int i = 0; i < count; i++)
        {
            if (itemImage == null)
                yield break;
            itemImage.sprite = itemSprites[i % itemSprites.Length];
            yield return new WaitForSeconds((time / count) * 2);
        }
        if (itemImage == null)
            yield break;
        itemImage.sprite = itemSprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
