using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //We should be 
        References.theCanvas = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
