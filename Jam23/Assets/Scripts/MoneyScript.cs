using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    private const string _text = "Гроші: ";
    public UserManager _userManager;

    public Text UserMoney;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Difficulty: " + _userManager.CurrentDifficultyLvl);
        UserMoney.text = _text + _userManager.Money.ToString();
    }
}
