using UnityEngine;
using System.Collections;

//On each Fish Indicator 
public class FishingSpot : MonoBehaviour
{
    private IEnumerator coroutine1;

    private void OnEnable()
    {
        coroutine1 = FishTimer(Random.Range(0.5f, 2));
        StartCoroutine(coroutine1);
    }

    private IEnumerator FishTimer(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            gameObject.SetActive(false);
        }
    }
}
