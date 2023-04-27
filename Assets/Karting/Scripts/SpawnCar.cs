using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;

public class SpawnCar : MonoBehaviour
{
    public Transform trans;
    public GameObject gameObj;
    public GameObject[] allVehicles;
    public CinemachineVirtualCamera cinemachineCamera; //m_LookAt, m_Follow
    public GameFlowManager gameFlowManager; //playerKart
    // Start is called before the first frame update
    void Awake()
    {
        int currentVehicle = VehicleSelector.currentVehicle;

        GameObject carroPlayer = Instantiate(allVehicles[currentVehicle], trans.position, Quaternion.identity);
        gameFlowManager.playerKart = carroPlayer.GetComponent<ArcadeKart>();
        cinemachineCamera.m_LookAt = carroPlayer.transform;
        cinemachineCamera.m_Follow = carroPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
