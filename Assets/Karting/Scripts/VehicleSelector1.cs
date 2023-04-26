using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelector1 : MonoBehaviour
{
    public GameObject[] allVehicles1;
    public static int currentVehicle1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextVehicle1()
    {
        allVehicles1[currentVehicle1].SetActive(false);

        currentVehicle1++;
        currentVehicle1 = currentVehicle1 % allVehicles1.Length;

        allVehicles1[currentVehicle1].SetActive(true);
    }

    public void PreviousVehicle1()
    { 
        allVehicles1[currentVehicle1].SetActive(false);

        currentVehicle1--;

        if(currentVehicle1<0)
        { 
            currentVehicle1 = allVehicles1.Length - 1;
        }

        allVehicles1[currentVehicle1].SetActive(true);
    }
}
