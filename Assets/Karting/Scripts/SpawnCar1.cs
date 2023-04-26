using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;

public class SpawnCar1 : MonoBehaviour
{
    public Transform trans1;
    public GameObject gameObj1;
    public GameObject[] allVehicles1;
    public CinemachineVirtualCamera cinemachineCamera1; //m_LookAt, m_Follow
    public GameFlowManager gameFlowManager; //playerKart
    // Start is called before the first frame update
    void Awake()
    {
        int currentVehicle1 = VehicleSelector1.currentVehicle1;

        GameObject carroPlayer1 = Instantiate(allVehicles1[currentVehicle1], trans1.position, Quaternion.identity);
        gameFlowManager.playerKart = carroPlayer1.GetComponent<ArcadeKart>();
        cinemachineCamera1.m_LookAt = carroPlayer1.transform;
        cinemachineCamera1.m_Follow = carroPlayer1.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
