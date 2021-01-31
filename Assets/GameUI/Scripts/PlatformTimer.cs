using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformTimer : MonoBehaviour
{
    [SerializeField] PlatformBehavior platform;
    [SerializeField] float timerSpeed;
    [SerializeField] Image timerFill;
    public bool timerIsEnded;
    Coroutine timerCo;

    public void StartTimer()
    {
        timerCo = StartCoroutine(StartPlatformTimer());
    }
    public void StopTimer()
    {
        if(timerCo != null)
            StopCoroutine(timerCo);

        timerFill.fillAmount = 1;
    }
    //public void ResumeTimer()
    //{

    //}
    IEnumerator StartPlatformTimer()
    {
        yield return new WaitUntil(ReduceTimerFill);
        timerIsEnded = true;
        StopCoroutine(timerCo);
    }
    bool ReduceTimerFill()
    {
        timerFill.fillAmount -= (timerSpeed * Time.deltaTime);

        return timerFill.fillAmount == 0;
    }
}
