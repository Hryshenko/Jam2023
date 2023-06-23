using UnityEngine;
using UnityEngine.UI;

public class PatientHistoryScript : MonoBehaviour
{
    public UserManager UserManager;
    public Text Text;
    public Image Image;

    private float _timeStarted;
    private bool _IsStarted;

    public int Duration = 8;
    // Start is called before the first frame update
    void Start()
    {
        this.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_IsStarted)
        {
            Image.sprite = null;
            Text.text = "";
            _IsStarted = true;
            _timeStarted = Time.time;
            
            var data = UserManager.GetDiseaseStory();
            Image.sprite = data.Photo;
            Text.text = data.Story;
        }

        if (_timeStarted + Duration < Time.time)
        {
            Image.sprite = null;
            Text.text = "";
            _timeStarted = 0;
            _IsStarted = false;
            this.SetActive(false);
        }
    }
}
