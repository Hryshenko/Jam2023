using UnityEngine;

public class User : MonoBehaviour
{
    public void Spawn(Transform transform) =>
        gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
}
