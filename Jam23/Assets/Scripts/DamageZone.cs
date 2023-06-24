using UnityEngine;
using UserData;

public class DamageZone : MonoBehaviour
{
    public Disease diseaseArea;
    private void OnTriggerEnter(Collider other)
    {
        var um = other.gameObject.GetComponent<UserManager>();
        if (um?.CurrentPatient == null)
            return;

        if (um.CurrentPatient.Patient.Diseases[0] != diseaseArea)
            return;

        um.EntryAnyStressArea(diseaseArea);
    }

    private void OnTriggerExit(Collider other)
    {
        var um = other.gameObject.GetComponent<UserManager>();
        if (um?.CurrentPatient == null)
            return;

        if (um.CurrentPatient.Patient.Diseases[0] != diseaseArea)
            return;

        um.ExitStressArea(diseaseArea);
    }
}
