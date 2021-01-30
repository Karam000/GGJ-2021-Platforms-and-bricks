using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformTimer : MonoBehaviour
{
    [SerializeField] float timerSpeed;
    [SerializeField] Image timerFill;
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
        StopCoroutine(timerCo);
    }
    bool ReduceTimerFill()
    {
        Debug.Log(timerSpeed * Time.deltaTime);
        timerFill.fillAmount -= (timerSpeed * Time.deltaTime);

        return timerFill.fillAmount == 0;
    }
}
