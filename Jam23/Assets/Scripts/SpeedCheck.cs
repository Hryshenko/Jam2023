using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheck : MonoBehaviour
{
    CarController SelectedCar { get { return MainController.PlayerCar; } }

    void Update()
    {
        if (SelectedCar == null)
            return;

        if (SelectedCar.SpeedInHour < 70)
            return;

        //call stress
    }
}
