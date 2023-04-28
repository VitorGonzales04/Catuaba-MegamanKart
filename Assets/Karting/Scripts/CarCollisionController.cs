using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


namespace KartGame.KartSystems
{
    public class CarCollisionController : MonoBehaviour
    {
        [SerializeField] private float power = 3f;
        private bool invincible = false;

        public bool Invincible
        {
            get
            {
                return invincible;
            }

            set
            {
                invincible = value;
            }
        }

        private ArcadeKart playerControl = null; 
        private ItemManager itemMgr = null; 

        // Start is called before the first frame update
        void Start()
        {
            if(gameObject.tag == "Player")
            {
                playerControl = gameObject.GetComponentInParent<ArcadeKart>();
                itemMgr = gameObject.GetComponentInParent<ItemManager>();
            }
        }

        public void EnableCar(bool state)
        {
            if (playerControl)
                playerControl.enabled = state;
            if (itemMgr)
                itemMgr.enabled = state;
        }

        public void StopCar()
        {
            gameObject.GetComponentInParent<ArcadeKart>().baseStats.TopSpeed = 0;
        }

        public void HitItem()
        {
            if(invincible)
            {
                EnableCar(false);
                StopCar();
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "LaunchableItem" && invincible)
            {
                Destroy(collider.gameObject);
            }
        }

        IEnumerator ReactiveVicatim(ArcadeKart arcadeKart)
        {
            yield return new WaitForSeconds(5f);
            arcadeKart.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
