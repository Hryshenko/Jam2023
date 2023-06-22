using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public int[] DifficultyMilestones = new[] { 2000, 4000, 7000 };
    
    public int CurrentDifficultyLvl = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money++;
    }

    public void GetNewPatient()
    {
        var pos = new Vector2(UserCar.position.x, UserCar.position.y);
        
        var patient = PatientManager.TryGetPatient(pos, CurrentDifficultyLvl);
        if (patient != null)
            CurrentPatient = new PickedPatient(patient, Time.time);
    }

    public void DropPatient()
    {
        if (CurrentPatient == null)
            throw new Exception("Try to drop null patient");

        var paid = CurrentPatient.CalculatePaid();
        Money += paid;
    }

    public void CalculateDifficulty()
    {
        if (CurrentDifficultyLvl >= (DifficultyMilestones.Count() - 1)
        || Money <= DifficultyMilestones[CurrentDifficultyLvl])
            return;

        CurrentDifficultyLvl++;
        CalculateDifficulty();
    }
}
