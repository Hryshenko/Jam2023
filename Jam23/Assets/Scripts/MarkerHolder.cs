using UnityEngine;

public class MarkerHolder : MonoBehaviour
{
    public static MarkerHolder Instance;

    public Camera minimapCamera;
    public GameObject markerPrefab;
    public GameObject playerObject;
    public RectTransform markerParentRectTransform;
    public RectTransform _missionRectTransform;

    private Mission _mission;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (_mission == null)
        {
            var mission = GameObject.FindObjectOfType<Mission>();
            if (!mission.enabled)
                return;

            _mission = mission;
            AddObjectiveMarker();

        }

        var offset = Vector3.ClampMagnitude(_mission.transform.position - playerObject.transform.position, minimapCamera.orthographicSize);
        offset = offset / minimapCamera.orthographicSize * (markerParentRectTransform.rect.width / 2f);
        _missionRectTransform.anchoredPosition = new Vector2(offset.x, offset.z);
    }

    public void AddObjectiveMarker()
    {
        _missionRectTransform = Instantiate(markerPrefab, markerParentRectTransform).GetComponent<RectTransform>();

    }

    public void RemoveObjectiveMarker()
    {
        _mission = null;
        _missionRectTransform = null;
    }
}
