using System;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    public UserManager UserManager;
    public Text Text;

    public Image Image;

    public Color InitialColor = new Color(124,221,139,223);
    public Color NoneColor = new Color(255, 255, 255, 30);
    public Color WarningColor = new Color(214, 96, 96, 223);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Start Update image");
        var patient = UserManager.CurrentPatient;
        if (patient == null)
        {
            Image.color = NoneColor;
            Text.text = "00:00";
            return;
        }
        
        var timeEnd = patient.ExpectedArrivalTime;

        var deltaTime = timeEnd - Time.time;
        bool isNegative = false;
        if (deltaTime < 0)
        {
            isNegative = true;
            Image.color = WarningColor;
        }
        else
        {
            Image.color = InitialColor;
        }
        //Debug.Log($"TimeExpected: {timeEnd} || Time now: {Time.time}");
        //Debug.Log($"Time: {deltaTime}");
        var minutes = deltaTime / 60;
        //Debug.Log($"Minutes: {minutes} - {(int)minutes}");
        //Debug.Log($"{deltaTime - ((int)(minutes))*60}");
        var neg = isNegative ? "-" : "";
        Text.text = $"{neg}{Math.Abs((int)minutes)}:{Math.Abs((int)(deltaTime - (int)minutes*60))}";
    }
}
