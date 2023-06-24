using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheck : MonoBehaviour
{
    private CarController SelectedCar { get { return MainController.PlayerCar; } }

    private bool _isInStress;
    private UserManager userManager;

    private void Awake()
    {
        userManager = gameObject.GetComponent<UserManager>();
    }

    private void Update()
    {
        if (SelectedCar == null)
            return;

        Debug.LogWarning(SelectedCar.SpeedInHour);
        if (SelectedCar.SpeedInHour < 110)
        {
            if (_isInStress)
            {
                _isInStress = false;
                userManager.ExitStressArea(UserData.Disease.Stress);
                return;
            }
            return;
        }

        if (_isInStress)
            return;

        _isInStress = true;
        userManager.EntryAnyStressArea(UserData.Disease.Stress);
    }
}
