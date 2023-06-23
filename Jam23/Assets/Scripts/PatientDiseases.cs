using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PatientDiseases : MonoBehaviour
{
    public UserManager UserManager;

    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dis = UserManager.GetPatientDiseases();
        if (dis == null)
        {
            Text.text = "No patient";
            return;
        }

        Debug.Log($"{dis.First().Key} ||| {dis.First().Value}");
        var t = new StringBuilder();
        foreach (var pair in dis)
        {
            t.AppendLine($"Disease: {pair.Key} \t lvl: {pair.Value}");
        }

        Text.text = t.ToString();
    }
}
