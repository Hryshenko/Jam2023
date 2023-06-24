using UnityEngine;
using UserData;

public class DamageZone : MonoBehaviour
{
    public Disease diseaseArea;
    private void OnTriggerEnter(Collider other) =>
        other.gameObject.GetComponent<UserManager>().EntryAnyStressArea(diseaseArea);

    private void OnTriggerExit(Collider other) =>
        other.gameObject.GetComponent<UserManager>().ExitStressArea(diseaseArea);
}
