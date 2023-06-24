using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public UserManager UserManager;
    public GameObject Heart;
    

    public List<GameObject> HeartPlaces;
    private List<GameObject> Hearts;

    private int currentHearts;
    // Start is called before the first frame update
    void Start()
    {
        Hearts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var health = UserManager.Health;
        if (health == currentHearts)
        {
            return;
        }
        else if (health > currentHearts)
        {
            var g = Instantiate(Heart, HeartPlaces[currentHearts].transform);
            Hearts.Add(g);
            currentHearts++;
            //Hearts[currentHearts].sprite = Heart.sprite;
            return;
        }
        else
        {
            Destroy(Hearts.Last());
            currentHearts--;
            return;
        }
    }
}
