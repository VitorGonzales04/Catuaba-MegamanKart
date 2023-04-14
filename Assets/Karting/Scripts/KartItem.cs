using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using static Item;

public class KartItem : MonoBehaviour
{
    private ArcadeKart Kart;
    private GameItemsHandle Handle;
    
    public float DelayBeforeItemPickup = 1;

    public int HeldItem;

    public bool CanPickup;
    private bool UseItem;

    public Item ItemUse;
    private Item RemainingItemUses;

    public void StartPickup()
    {
        StartCoroutine(PickUp());
    }

    public void ResetItem()
    {
        ItemUse = null;
        HeldItem = -1;
        CanPickup = true;
    }

    public IEnumerator PickUp()
    {
        if (HeldItem == -1 && CanPickup)
        {
            CanPickup = false;

            yield return new WaitForSeconds(DelayBeforeItemPickup);

            int ItemRandomizer = Random.Range(0, Handle.AllItems.Length);

            ItemUse = Handle.AllItems[ItemRandomizer];

            HeldItem = ItemRandomizer;
            RemainingItemUses = ItemUse.Uses;
        }
    }

    public void ActivateItem()
    {
        RemainingItemUses -= 1;

        /*if(ItemUse.Boost.Length > 0)
        {
            foreach (ItemBoostFunction ItemBoost in ItemUse.Boost)
            {
                Kart.Boost(ItemBoost.BoostAmt);
            }
        }*/

        if(RemainingItemUses <= 1)
        {
            ResetItem();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       Handle = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameItemsHandle>();
       
       Kart = GetComponent<ArcadeKart>();

       ResetItem();
    }

    // Update is called once per frame
    void Update()
    {
        UseItem = Input.GetButtonDown("Item");
        if (UseItem && HeldItem != -1)
        {
            ActivateItem();
        } 
    }
}