using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]

namespace Items
{
    public class Item : MonoBehaviour
    {
        public string Name;
        public string description;
        public int Uses;

        public ItemBoostFunction[] Boost;

        public Sprite Visual;

        protected GameObject owner = null;
        [SerializeField] protected string type;
        public string Type { get { return type; } }
        protected ItemManager itemMgr;

        [SerializeField] protected float duration;

        public virtual void SetOwner(GameObject newOwner)
        {
            owner = newOwner;
            itemMgr = owner.GetComponent<ItemManager>();
        }
    }
}