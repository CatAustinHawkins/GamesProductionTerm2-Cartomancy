using System.Collections;
using UnityEngine;

//work in progress script for the wheel of fortune

public class WheelofFortune : MonoBehaviour
{
    public int RandomWheelValue;

    public void WheelSpin()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        RandomWheelValue = Random.Range(12, 1);

        StartCoroutine(Rotate(3f));
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + (RandomWheelValue * 30);
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            yield return null;
        }
    }
}
