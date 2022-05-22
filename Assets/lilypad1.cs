using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilypad1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up, Random.Range(0, 360f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
