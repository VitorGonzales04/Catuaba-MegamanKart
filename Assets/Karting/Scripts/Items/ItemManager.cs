using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemManager : MonoBehaviour
    {
        Item item;
        [SerializeField] Item itemInst;

        public delegate void OnLaunchDelegate();
        public event OnLaunchDelegate OnDefaultLaunch;

        private enum DropState
        {
                Default = 0,
                Forward = 1,
                Backward = 2
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
          if(Input.GetButtonDown("Jump"))
          {
                if(item)
                {
                    if (itemInst == null && item.tag == "LaunchableItem")
                        dragItem();
                    else
                        useItem();
                }
          }

          if(itemInst && itemInst.tag == "LaunchableItem")
          {
                if(Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0 && Input.GetButtonUp("Jump"))
                {
                    dropItem(DropState.Forward);
                    return;
                }

                if(Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0 && Input.GetButtonUp("Jump"))
                {
                    dropItem(DropState.Backward);
                    return;
                }

                if(Input.GetButtonUp("Jump"))
                {
                    dropItem(DropState.Default);
                }
          }
        }

        private bool isntantiateItem()
        {
            if(item && !itemInst)
            {
                itemInst = Instantiate(item);
                itemInst.SetOwner(gameObject);
                item = null;
                return true;
            }

            return false;
        }

        private void dragItem()
        {
            if(instantiateItem())
            {
                itemInst.transform.position = gameObject.transform.position + new Vector3(0, 1f, 3);
            }
        }

        private void dropItem(DropState state)
        {
            if (itemInst == null)
                return;

            switch(state)
            {
                case DropState.Forward:
                {
                        itemInst.GetComponent<LaunchableItem.LaunchableItem>().LaunchForward();
                        break;
                }
                case DropState.Backward:
                {
                        itemInst.GetComponent<LaunchableItem.LaunchableItem>().LaunchBackward();
                        break;
                }
                case DropState.Default:
                {
                        OnDefaultLaunch();
                        break;
                }
                default:
                {
                        break;
                }
            }
        }

            private void useItem()
            {
                if(instantiateItem()
                {
                    itemInst.GetComponent<UseableItem.UseableItem>().use();
                    itemInst = null;
                    if (GuiManager.Instance)
                        GuiManager.Instance.ChangeItem("");
                }
            }

            public void setItem(Item newItem)
            {
                if (!item)
                {
                    StartCoroutine(RouletteCoroutine(newItem));
                }
            }

            IEnumerator RouletteCoroutine(Item newItem)
            {
                if (gameObject.name != "Player")
                    yield break;
                if (GuiManager.Instance)
                    GuiManager.Instance.ChangeItem(newItem.Type);
                yield return new WaitForSeconds(3);
                item = newItem;
            }
     }
}












