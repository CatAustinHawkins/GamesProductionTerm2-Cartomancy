using UnityEngine;
using System.Collections;

//script on all traps
public class Traps : MonoBehaviour
{
    private IEnumerator coroutine1;

    void Start()
    {
        coroutine1 = CardTextTimer(5);
        StartCoroutine(coroutine1);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Trap"); //Find GameObjects in the scene labelled with the tag 'Trap'

        if (objs.Length > 1) //if there is more than one GameObject with the tag 'Trap' in the scene
        {
            Destroy(gameObject); //destory the current GameObject - to ensure that there is only one Trap in the scene.
        }
    }


    private IEnumerator CardTextTimer(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            Destroy(gameObject); //destory the trap so the player can place another
        }
    }

}
