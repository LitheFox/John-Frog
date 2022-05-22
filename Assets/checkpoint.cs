using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, Mathf.Sin(Time.time * 100f)* .0005f, 0);
        transform.Rotate(Vector3.up, 1);
    }
}
