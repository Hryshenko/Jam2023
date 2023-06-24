using UnityEngine;

public class MarkerHolder : MonoBehaviour
{
    public static MarkerHolder Instance;

    public Camera minimapCamera;
    public GameObject markerPrefab;
    public GameObject playerObject;
    public RectTransform markerParentRectTransform;
    public RectTransform _missionRectTransform;

    private GameObject _mission;

    private void Awake() =>
        Instance = this;

    public void Set(GameObject go)
    {
        if (_mission != null)
            return;

        markerPrefab.SetActive(true);

        _mission = go;
        AddObjectiveMarker();
    }

    private void Update()
    {
        if (_mission == null)
            return;

        var offset = Vector3.ClampMagnitude(_mission.transform.position - playerObject.transform.position, minimapCamera.orthographicSize);
        offset = offset / minimapCamera.orthographicSize * (markerParentRectTransform.rect.width / 2f);
        _missionRectTransform.anchoredPosition = new Vector2(offset.x, offset.z);
    }

    public void AddObjectiveMarker() =>
        _missionRectTransform = Instantiate(markerPrefab, markerParentRectTransform).GetComponent<RectTransform>();

    public void RemoveObjectiveMarker()
    {
        Destroy(_missionRectTransform.gameObject);

        _mission = null;
        _missionRectTransform = null;
    }
}
