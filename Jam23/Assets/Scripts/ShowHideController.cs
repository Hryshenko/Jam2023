using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideController : MonoBehaviour
{
    public static ShowHideController Instance;
    public ShowHideUI Stress;

    private void Awake()
    {
        Instance = this;
    }
}
