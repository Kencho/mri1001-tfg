using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void ScaleTime(float timeScale, float timeModificationDuration = 0)
    {
        Time.timeScale *= timeScale;
        if(timeModificationDuration != 0)
        {
            StartCoroutine(UnscaleTime(timeScale, timeModificationDuration));
        }
    }

    private IEnumerator UnscaleTime(float timeScale, float timeModificationDuration)
    {
        yield return new WaitForSeconds(timeModificationDuration);
        ScaleTime(1 / timeScale);
    }
}
