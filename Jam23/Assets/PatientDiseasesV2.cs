using System.Collections;
using System.Collections.Generic;
using StaticData;
using UnityEngine;

public class PatientDiseasesV2 : MonoBehaviour
{
    public UserManager UserManager;

    public List<DiseasePanel> DiseasePanels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UserManager.CurrentPatient == null)
            return;

        var diseases = UserManager.CurrentPatient.GetPatientDiseases();
        var data = StoryGenerator.GenerateDiseaseData(diseases);

        int i = 0;
        foreach (var dis in data)
        {
            DiseasePanels[i].DiseaseData = dis;
            i++;
        }
    }
}
