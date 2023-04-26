using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items; 

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    public Item[] itemPrefabs; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItemIndex(string str)
    {
        for (int i = 0; i < itemPrefabs.Length; i++)
            if (str == itemPrefabs[i].Type)
                return i;
        return -1;
    }

}
