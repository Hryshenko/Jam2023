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
            Instantiate(FinishZoneObject);
            FinishZoneObject.transform.position = new Vector3(um.CurrentPatient.Destination.x, 5, um.CurrentPatient.Destination.y);
        }
    }
}
