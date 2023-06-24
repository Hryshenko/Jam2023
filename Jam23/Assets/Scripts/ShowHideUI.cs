using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    public float showX;
    public float hideX;
    public RectTransform transform;

    public void ShowUI() =>
        StartCoroutine(Show());

    private IEnumerator Show()
    {
        float currentTime = 0;
        while (currentTime < 2)
        {
            currentTime += Time.deltaTime;
            transform.SetLocalX(Mathf.Lerp(hideX, showX, (currentTime / 2)));
            //Debug.LogError(_group.alpha);
            yield return null;

        }
        yield break;
    }
    public void HideUI() =>
        StartCoroutine(Hide());

    private IEnumerator Hide()
    {
        float currentTime = 0;
        while (currentTime < 2)
        {
            currentTime += Time.deltaTime;
            transform.SetLocalX(Mathf.Lerp(showX, hideX, (currentTime / 2)));
            //Debug.LogError(_group.alpha);
            yield return null;

        }
        yield break;
    }
}
