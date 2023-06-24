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
    public MainUI UI;
    
    
    public PickedPatient CurrentPatient;

    public PatientHistoryPanel PatientHistoryPanel;


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
    private List<Disease> ActiveTriggers = new List<Disease>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Money++;

        if (_isPatientStress && CurrentPatient != null)
        {
            var deltaTime = Time.deltaTime;
            CurrentPatient.IncreaseStress(deltaTime, ActiveTriggers);
            CheckStress();
        }
    }

    public void GetNewPatient()
    {
        if (CurrentPatient != null)
        {
            Debug.LogWarning($"CurrentPatient != null");
            return;
        }
        
        var patient = PatientManager.TryGetPatient(GetCarPos(), CurrentDifficultyLvl);
        if (patient != null)
        {
            CurrentPatient = new PickedPatient(patient, Time.time, GetCarPos());
            Debug.LogWarning($"InitialPaid: {patient.InitialPaid}");
            PatientHistoryPanel.EnableCart(this, 1);
            return;
        }
        Debug.LogWarning($"No available patient");
    }

    public Dictionary<Disease, int> GetPatientDiseases()
    {
        if (CurrentPatient != null)
            return CurrentPatient.GetPatientDiseases();

        return null;
    }

    public PatientStoryData GetDiseaseStory()
    {
        return StoryGenerator.GenerateDiseaseStory(this);
    }

    public void DropPatient()
    {
        if (CurrentPatient == null)
            throw new Exception("Try to drop null patient");

        if (Vector2.Distance(GetCarPos(), CurrentPatient.Destination) > PatientStaticData.PickUpRange)
            return;
        
        var paid = CurrentPatient.CalculatePaid();
        Money += paid;

        EndTravel();
    }

    public void CancelPatient()
    {
        var go = GameObject.FindObjectOfType<FinishZone>();
        if (go != null)
            Destroy(go.gameObject);

        MarkerHolder.Instance.RemoveObjectiveMarker();

        CurrentPatient = null;
        Health--;

        if (Health == 0)
        {
            LoseGame();
        }
    }

    public void EntryAnyStressArea(Disease diseaseArea)
    {
        if (ActiveTriggers.Contains(diseaseArea))
        {
            Debug.Log($"Already in stress area {diseaseArea}");
            return;
        }
        
        _isPatientStress = true;
        ActiveTriggers.Add(diseaseArea);
    }

    public void TriggerTriggerED()
    {
        if (!CurrentPatient.CheckIsTrigger(Disease.ED))
            return;
        
        CurrentPatient.InstantStressIncrease(PatientStaticData.StressIncreasePerRotateWithED);
        
    }

    #region StressTestMethods

    public void EntryAnyStressAreaTestOnly()
    {
        var diseaseArea = Disease.Depression;
        if (CurrentPatient == null)
            return;

        _isPatientStress = true;
        ActiveTriggers.Add(diseaseArea);
    }

    public void ExitStressAreaTestOnly()
    {
        var triggerArea = Disease.Depression;
        ActiveTriggers.Remove(triggerArea);
        if (!ActiveTriggers.Any())
            _isPatientStress = false;
        
        Debug.Log($"Strop trigger {triggerArea}");
    }
    
    #endregion

    public void ExitStressArea(Disease triggerArea)
    {
        ActiveTriggers.Remove(triggerArea);
        if (!ActiveTriggers.Any())
            _isPatientStress = false;
        
        Debug.Log($"Strop trigger {triggerArea}");
    }

    private void CheckStress()
    {
        if (CurrentPatient.StressPercent < 100)
            return;
        
        CancelPatient();
        Debug.Log("Patient canceled | out of stress");
    }

    private void CalculateDifficulty()
    {
        Debug.Log($"Current diffic {CurrentDifficultyLvl}");
        //Debug.Log($"Count {PatientStaticData.DifficultyMilestones.Length}");
        //Debug.Log("");
        if (CurrentDifficultyLvl > (PatientStaticData.DifficultyMilestones.Length - 1)
        || Money <= PatientStaticData.DifficultyMilestones[CurrentDifficultyLvl])
            return;

        Debug.Log("");
        if (Money >= PatientStaticData.FinalPoint)
            WinGame();
        Debug.Log("");
        CurrentDifficultyLvl++;
        CalculateDifficulty();
    }

    private void WinGame()
    {
        Debug.Log("Win Game");
        UI.FinishGame(true);
    }

    private Vector2 GetCarPos()
    {
        var pos = UserCar.position;
        return new Vector2(pos.x, pos.y);
    }

    private void EndTravel()
    {
        Debug.Log("End travel");
        CurrentPatient = null;
    }

    public void LoseGame()
    {
        Debug.Log("Death end");
        UI.FinishGame(false);
    }
}
