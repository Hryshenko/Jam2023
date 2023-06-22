using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UserData;

public class PatientManager : MonoBehaviour
{
    public List<Vector2> AvailablePatientPositions; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Patient TryGetPatient(Vector2 userPos, int difficultyLvl)
    {
        if (!AvailablePatientPositions.Contains(userPos))
            return null;

        AvailablePatientPositions.Remove(userPos);
        return new Patient(difficultyLvl);
    }
}
