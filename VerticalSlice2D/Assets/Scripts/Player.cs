using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float TP = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TP > 100)
        {
            TP = 100;
        }
        if (TP < 0)
        {
            TP = 0;
        }
    }
}
