using System.Collections;
using System.Collections.Generic;
using StaticData;
using UnityEngine;
using UnityEngine.UI;

public class DiseasePanel : MonoBehaviour
{
    public Image Image;
    public Text Text;

    private Color InitialColor = new Color(255,255,255, 50);

    public DiseaseData DiseaseData;
    
    //public Color DiseaseColor = new Color(0,0,0,0.5f);
    // Start is called before the first frame update
    void Start()
    {
        //InitialColor = Image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (DiseaseData != null)
        {
            //Debug.Log($"Data: {DiseaseData.Disease}");
            Image.color = DiseaseData.Color;
            var str = StoryGenerator.GenerateDiseaseAnnotation(DiseaseData);
            //Debug.Log($"123 || {str}");
            Text.text = str;
        }
        else
        {
            Text.text = "";
            Image.color = InitialColor;
        }
    }
}
