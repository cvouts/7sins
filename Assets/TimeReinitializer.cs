using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReinitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
        	Time.timeScale = 1;
        }
    }
}
