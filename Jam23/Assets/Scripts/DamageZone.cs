using UnityEngine;
using UserData;

public class DamageZone : MonoBehaviour
{
    public Disease diseaseArea;
    private void OnCollisionEnter(Collision collision) =>
        collision.gameObject.GetComponent<UserManager>().EntryAnyStressArea(diseaseArea);

    private void OnCollisionExit(Collision collision) =>
        collision.gameObject.GetComponent<UserManager>().ExitStressArea(diseaseArea);
}
