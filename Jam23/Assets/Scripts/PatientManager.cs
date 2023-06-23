using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;
using UserData;

public class PatientManager : MonoBehaviour
{
    public List<Sprite> Photos;
    public List<Vector2> AvailablePatientPositions; 
    // Start is called before the first frame update

    private bool _isProfilesGenerated;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isProfilesGenerated) GenerateProfiles();
        if (AvailablePatientPositions == null)
            GenerateAvailablePatients();
    }

    public Patient TryGetPatient(Vector2 userPos, int difficultyLvl)
    {
        Debug.Log("Start");
        Debug.Log($"Try pickup {AvailablePatientPositions[0]} user: {userPos}");
        
        if (!AvailablePatientPositions.Any(p =>
                Vector2.Distance(userPos, p) <= PatientStaticData.PickUpRange))
        {
            Debug.Log("No patient");
            return null;
        }
        
        var patientPos = AvailablePatientPositions.FirstOrDefault(p =>
            Vector2.Distance(userPos, p) <= PatientStaticData.PickUpRange);

        AvailablePatientPositions.Remove(patientPos);
        Debug.Log($"Available patients: {AvailablePatientPositions.Count}");
        return new Patient(difficultyLvl);
    }

    private void GenerateAvailablePatients()
    {
        AvailablePatientPositions = new List<Vector2>();

        foreach (var sp in PatientStaticData.ListOfAvailablePatientSpawnPoints)
        {
            AvailablePatientPositions.Add(sp);
        }
    }

    private void GenerateProfiles()
    {
        foreach (var p in Photos)
        {
            var pat = PatientStaticData.PatientEmptyProfiles[p.name]; 
            pat.Photo = p;
            if (PatientStaticData.PatientProfiles == null)
                PatientStaticData.PatientProfiles = new List<PatientProfile>();
            PatientStaticData.PatientProfiles.Add(pat);
        }
    }
}