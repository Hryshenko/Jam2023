using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<UserManager>().DropPatient();
        MarkerHolder.Instance.RemoveObjectiveMarker();
        Destroy(gameObject);
    }
}
