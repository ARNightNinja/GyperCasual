using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerCustom : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text countDownT;
    public UnityEvent onTimerStarted;
    public UnityEvent onTimerEnded;
    
    public void StartTimer(int secs)
    {
        StartCoroutine(CountDown(secs));
    }
    IEnumerator CountDown(int secsLeft)
    {
        onTimerStarted?.Invoke();
        countDownT.text = TimeToString(secsLeft);
        while (secsLeft>=0)
        {
            yield return new WaitForSecondsRealtime(1);
            secsLeft--;
            countDownT.text = TimeToString(secsLeft);
        }
        onTimerEnded?.Invoke();
    }
    string TimeToString(float _time)
    {
        int hrsTime = (int)(_time / 60 / 60);
        int minTime = (int)(_time / 60) % 60;
        int secTime = (int)(_time % 60);
        int msTime = (int)((_time % 1) * 100 % 100);

        string msecStr = msTime < 10 ? "0" + msTime : "" + msTime;
        string secStr = secTime < 10 ? "0" + secTime : "" + secTime;
        string minStr = minTime < 10 ? "0" + minTime : "" + minTime;
        string hrsStr = hrsTime < 10 ? "0" + hrsTime : "" + hrsTime;
        
        return hrsStr + ":" + minStr + ":" + secStr;
    }
}
