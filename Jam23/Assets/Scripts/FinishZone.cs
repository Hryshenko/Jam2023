using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserData;

public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var um = other.gameObject.GetComponent<UserManager>();

        if (um.CurrentPatient.Patient.Diseases[0] == Disease.Stress)
            Destroy(other.gameObject.GetComponent<SpeedCheck>());

        MarkerHolder.Instance.RemoveObjectiveMarker();
        MissionsController.Instance.ShowMissions();
        um.DropPatient();

        Destroy(gameObject);
    }
}
