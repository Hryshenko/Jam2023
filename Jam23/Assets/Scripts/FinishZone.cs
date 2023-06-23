using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) =>
        collision.gameObject.GetComponent<UserManager>().DropPatient();
}
