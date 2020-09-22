using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeBasedActivator : MonoBehaviour
{
    public float TimeUntilStart;
    public UnityEvent TimeBaseEvent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
	{
        yield return new WaitForSeconds(TimeUntilStart);
        TimeBaseEvent.Invoke();

	}
    
}
