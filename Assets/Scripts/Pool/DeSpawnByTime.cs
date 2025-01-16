using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByTime : MonoBehaviour
{
    public float time;
    Coroutine coroutine;

    void OnEnable()
    {
        coroutine = StartCoroutine(CurrentEnumrator());
    }

    IEnumerator CurrentEnumrator()
    {
        yield return new WaitForSeconds(time);
        coroutine = null;
        SmartPool.Instance.Despawn(gameObject);
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}