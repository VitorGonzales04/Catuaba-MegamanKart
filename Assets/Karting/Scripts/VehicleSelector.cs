using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelector : MonoBehaviour
{
    public GameObject[] allVehicles;
    public static int currentVehicle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextVehicle()
    {
        allVehicles[currentVehicle].SetActive(false);

        currentVehicle++;
        currentVehicle = currentVehicle % allVehicles.Length;

        allVehicles[currentVehicle].SetActive(true);
    }

    public void PreviousVehicle()
    { 
        allVehicles[currentVehicle].SetActive(false);

        currentVehicle--;

        if(currentVehicle<0)
        { 
            currentVehicle = allVehicles.Length - 1;
        }

        allVehicles[currentVehicle].SetActive(true);
    }

    public void SelectVehicle(int sceneID)
    {
        SceneManager.LoadScene("MainScene");
    }
}
