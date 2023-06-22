using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;
using UserData;

public class UserManager : MonoBehaviour
{
    private int _money;

    public PatientManager PatientManager;
    public Transform UserCar;
    
    
    public PickedPatient CurrentPatient;


    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            CalculateDifficulty();
        }
    }

    public int Health = UserStaticData.InitialHealth;

    private int CurrentDifficultyLvl = 0;

    private bool _isPatientStress;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money++;

        if (_isPatientStress)
        {
            var deltaTime = Time.deltaTime;
            var deltaStress = PatientStaticData.StressPerSecond * deltaTime;
            CurrentPatient.IncreaseStress(deltaStress);
        }
    }

    public void GetNewPatient()
    {
        var patient = PatientManager.TryGetPatient(GetCarPos(), CurrentDifficultyLvl);
        if (patient != null)
            CurrentPatient = new PickedPatient(patient, Time.time);
    }

    public string GetPatientDiseases()
    {
        var resp = "";
        foreach (var disease in CurrentPatient.GetPatientDiseases())
        {
            resp += $"{disease}\n";
        }

        return resp;
    }

    public string GetDiseaseStory()
    {
        return "DiseaseStory";
    }

    public void DropPatient()
    {
        if (CurrentPatient == null)
            throw new Exception("Try to drop null patient");

        if (Vector2.Distance(GetCarPos(), CurrentPatient.Destination) > PatientStaticData.PickUpRange)
            return;
        
        var paid = CurrentPatient.CalculatePaid();
        Money += paid;
    }

    public void CancelPatient()
    {
        CurrentPatient = null;
        Health--;
    }

    public void EntryAnyStressArea(Disease diseaseArea)
    {
        if (CurrentPatient == null)
            return;

        if (CurrentPatient.CheckIsTrigger(diseaseArea))
            BeginStress();
    }

    public void ExitStressArea()
    {
        if (CurrentPatient == null)
            return;

        _isPatientStress = false;
        Debug.Log("Stress ended");
    }

    private void CheckStress()
    {
        if (CurrentPatient.StressPercent < 100)
            return;
        
        CancelPatient();
        Debug.Log("Patient canceled");
    }
    
    private void BeginStress()
    {
        _isPatientStress = true;
        Debug.Log("Stress Started");
    }

    private void CalculateDifficulty()
    {
        if (CurrentDifficultyLvl >= (PatientStaticData.DifficultyMilestones.Count() - 1)
        || Money <= PatientStaticData.DifficultyMilestones[CurrentDifficultyLvl])
            return;

        if (Money >= PatientStaticData.FinalPoint)
            EndGame();
        
        CurrentDifficultyLvl++;
        CalculateDifficulty();
    }

    private void EndGame()
    {
        
    }

    private Vector2 GetCarPos()
    {
        var pos = UserCar.position;
        return new Vector2(pos.x, pos.y);
    }
}
