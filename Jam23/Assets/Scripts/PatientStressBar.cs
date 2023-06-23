using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientStressBar : MonoBehaviour
{
    public UserManager UserManager;

    public Slider StressBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var patient = UserManager.CurrentPatient;
        if (patient == null)
        {
            StressBar.value = 0;
            //TODO: diable stressBar
            return;
        }

        StressBar.value = patient.StressPercent;
    }
}
