using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Trap");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1 * Time.deltaTime;
        if(timer > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
