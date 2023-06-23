using UnityEngine;

public class Minimap : MonoBehaviour
{
    public float angle;

    public Transform minimapOverlay;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + Vector3.up * 5f;
        RotateOverlay();
    }

    private void RotateOverlay()
    {
        minimapOverlay.localRotation = Quaternion.Euler(0, 0, player.eulerAngles.y - angle);
    }
}
