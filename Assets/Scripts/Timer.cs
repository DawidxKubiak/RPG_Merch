using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] int duration;
    [SerializeField] int remainingDuration;

    [SerializeField] UnityEvent onEnd;

    private void Start()
    {
        Being(duration);
    }

    void Being(int seconds)
    {
        remainingDuration = seconds;
        StartCoroutine( UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            text.text = $"{remainingDuration/60:00} : {remainingDuration%60:00}";
            image.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }

        OnEnd();
    }

    void OnEnd()
    {
        onEnd?.Invoke();
    }
}
