using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var dis = UserManager.GetPatientDiseases();
        // if (dis == null)
        // {
        //     Text.text = "No patient";
        //     return;
        // }
        //
        // //Debug.Log($"{dis.First().Key} ||| {dis.First().Value}");
        // var t = new StringBuilder();
        // foreach (var pair in dis)
        // {
        //     t.AppendLine($"{pair.Key} \t lvl: {pair.Value}");
        // }
        //
        // Text.text = t.ToString();
        //text.text = "123123";
    }
}
