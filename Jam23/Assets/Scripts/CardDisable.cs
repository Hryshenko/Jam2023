using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisable : MonoBehaviour
{
    private CanvasGroup _group;
    private void Start()
    {
        _group = gameObject.GetComponent<CanvasGroup>();
        if (_group == null)
            _group = gameObject.AddComponent<CanvasGroup>();
    }

    public void DisableCart(int time)
    {
        StartCoroutine(Disabling(time));
    }

    public IEnumerator Disabling(int time)
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

    public IEnumerator Enabling(int time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            _group.alpha = Mathf.Lerp(0, 1, (currentTime / time));
            yield return null;

        }

        DisableCart(time);

        yield break;
    }
}
