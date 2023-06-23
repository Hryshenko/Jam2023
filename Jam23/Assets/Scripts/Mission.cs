using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject MiniMapMarker;

    public void EnableMarker() =>
        MiniMapMarker.SetActive(true);

    public void DisableMarker() =>
        MiniMapMarker.SetActive(false);
}
