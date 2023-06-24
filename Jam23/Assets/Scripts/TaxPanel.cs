using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxPanel : MonoBehaviour
{
    public Text Text;

    public UserManager UserManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentPatient = UserManager.CurrentPatient;
        if (currentPatient == null)
        {
            Text.text = "Такса: 0";
            return;
        }

        var tax = currentPatient.CalculatePaid();
        if (tax < 0)
        {
            UserManager.CancelPatient();
            return;
        }

        Text.text = $"Такса: {tax}";
    }
}
