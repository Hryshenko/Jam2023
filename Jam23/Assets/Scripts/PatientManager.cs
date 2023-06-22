using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;
using UserData;

public class PatientManager : MonoBehaviour
{
    public List<Vector2> AvailablePatientPositions = new List<Vector2>(){new Vector2(1, 1)}; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AvailablePatientPositions.Any())
            AvailablePatientPositions.Add(new Vector2(0, 0));
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
}
