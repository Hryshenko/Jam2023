using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientHistoryPanel : MonoBehaviour
{
    public UserManager UserManager;
    public Text Text;
    public Image Image;
    
    // Start is called before the first frame update
    private CanvasGroup _group;
    private void Start()
    {
        _group = gameObject.GetComponent<CanvasGroup>();
        if (_group == null)
            _group = gameObject.AddComponent<CanvasGroup>();
        
        //Image.sprite = null;
        //Text.text = "";
        _group.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void DisableCart(int time)
    {
        StartCoroutine(Disabling(time));
    }
    
    public void EnableCart(UserManager manager, int time)
    {
        //Debug.LogError(UserManager == null);//true
        Debug.LogWarning("StartHistory");
        var data = manager.GetDiseaseStory();
        
        Image.sprite = data.Photo;
        Text.text = data.Story;
        
        StartCoroutine(Enabling(time));
    }

    private IEnumerator Disabling(int time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            _group.alpha = Mathf.Lerp(1, 0, (currentTime / time));
            Debug.LogError(_group.alpha);
            yield return null;

        }
        yield break;
    }

    private IEnumerator Enabling(int time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            _group.alpha = Mathf.Lerp(0, 1, (currentTime / time));
            yield return null;

        }
        
        yield return new WaitForSeconds(8);
        DisableCart(1);
        
        yield break;
    }
}
