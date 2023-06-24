using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserData;
using StaticData;

public class PickUpZone : MonoBehaviour
{
    public GameObject FinishZoneObject;

    private void OnTriggerEnter(Collider other)
    {
        var um = other.gameObject.GetComponent<UserManager>();
        if (um.CurrentPatient == null)
        {
            um.GetNewPatient();
            var go = Instantiate(FinishZoneObject);
            
            FinishZoneObject.transform.position = new Vector3(um.CurrentPatient.Destination.x, 5, um.CurrentPatient.Destination.y);
            
            MarkerHolder.Instance.Set(go);
            MissionsController.Instance.HideMissions();

            if (um.CurrentPatient.Patient.Diseases[0] == Disease.Stress)
                other.gameObject.AddComponent<SpeedCheck>();
        }
    }
}
