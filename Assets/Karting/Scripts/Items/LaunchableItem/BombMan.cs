using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items.LaunchableItem
{
    public class BombMan : LaunchableItem 
    {
        [SerializeField] private float speedMultiply;
        private float speed;

        private Vector3 bomb_velocity;
        private int rebound = 0;
        [SerializeField] private int maxRebound;
        private Vector3 direction;

        public string Print = "";

        private void FixedUpdate()
        {
            FixedUpdateLaunchable();
            if(isLaunch)
            {
                transform.position += transform.forward * Mathf.Max(speed, 1f) * Time.deltaTime;
                RaycastHit groundHit;

                if(Physics.Raycast(transform.position, -transform.up, out groundHit))
                {
                    if(groundHit.distance > 1f)
                    {
                        transform.LookAt(transform.forward + transform.position - new Vector3(0, 9.8f, 0) * Time.fixedDeltaTime);
                    }
                    else if(groundHit.distance < .8f)
                    {
                        Vector3 position = transform.position;
                        position.y = groundHit.point.y + .95f;
                        transform.position = position;
                        Vector3 target = (transform.forward + transform.position);
                        target.y = groundHit.point.y + .95f;
                    }
                }
            }
        }

        public override void AddDefaultLaunch()
        {
           itemMgr.OnDefaultLaunch += LaunchForward;
        }

        public override void LaunchForward()
        {
            if(owner)
            {
                transform.position =
                    owner.gameObject.transform.position +
                    new Vector3(0, 1f, 0) +
                    (owner.gameObject.transform.forward * launchDistance);
                speed = owner.GetComponent<ArcadeKart>().baseStats.Acceleration * speedMultiply;
            }

            GetComponent<SphereCollider>().isTrigger = false;

            isLaunch = true;

            if (itemMgr)
                itemMgr.OnDefaultLaunch -= LaunchForward;
        }

        public override void LaunchBackward()
        {
            transform.eulerAngles = Vector3.back;

            isLaunch = true;

            GetComponent<SphereCollider>().isTrigger = false;

            if (itemMgr)
                itemMgr.OnDefaultLaunch -= LaunchForward;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "EnemyCollider")
            {
                CarCollCtl = collider.gameObject.GetComponent<CarCollisionController>();
                CarCollCtl.HitItem();
                Hide("Sphere");
                Destroy(gameObject, duration);
            }

            if(collider.gameObject.tag == "LaunchableItem")
            {
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            {
                CarCollCtl = collision.gameObject.GetComponent<CarCollisionController>();
                if (!CarCollCtl)
                    return;
                CarCollCtl.HitItem();
                Hide("Sphere");
                Destroy(gameObject, duration);
            }

            if(collision.gameObject.tag == "LaunchableItem")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            if(collision.collider.CompareTag("Wall") && isLaunch)
            {
                Debug.Log(transform.eulerAngles);
                foreach(ContactPoint contact in collision.contacts)
                {
                    Vector3 reflectDir = Vector3.Reflect(transform.forward, contact.normal);
                    transform.LookAt(reflectDir + transform.position);
                }

                rebound += 1;
                if(rebound >= maxRebound)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            if (CarCollCtl)
                CarCollCtl.EnableCar(true);
            if (itemMgr)
                itemMgr.OnDefaultLaunch -= LaunchForward;
        }

        void CheckWall(Vector3 reflectDir)
        {
            RaycastHit hit;

            float leftDistance = 100f;
            float rightDistance = 100f;

            if (Physics.Raycast(transform.position, -transform.right, out hit))
                leftDistance = hit.distance;
            if (Physics.Raycast(transform.position, transform.right, out hit))
                rightDistance = hit.distance;

            if (leftDistance > rightDistance)
            {
                print("right");
                transform.rotation = Quaternion.FromToRotation(transform.position, -reflectDir);
            }
            else
            {
                print("left");
                transform.rotation = Quaternion.FromToRotation(transform.position, reflectDir);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
