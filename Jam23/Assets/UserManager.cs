using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UserData;

public class UserManager : MonoBehaviour
{
    private int _money;
    
    public Patient CurrentPatient;
    

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
        CurrentPatient = new Patient(Time.time, CurrentDifficultyLvl);
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
