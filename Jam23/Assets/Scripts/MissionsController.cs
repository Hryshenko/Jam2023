using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsController : MonoBehaviour
{
    public static MissionsController Instance;
    public GameObject[] Missions;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void HideMissions()
    {
        foreach (var mission in Missions)
            mission.SetActive(false);
    }

    public void ShowMissions()
    {
        foreach (var mission in Missions)
            mission.SetActive(true);
    }
}
