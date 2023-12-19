using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public UnityEvent myEvent; // UnityEvent that will be invoked after a delay
    //public float delayTime = 5f; // Delay time in seconds

    public void TimedEventTrigger(float delayTime)
    {
        StartCoroutine(InvokeEventAfterDelay(delayTime));
    }

    IEnumerator InvokeEventAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        myEvent.Invoke();
    }
}
