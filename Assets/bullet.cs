using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 vel;
    float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel;

        lifetime += Time.deltaTime;

        if (lifetime > 10000)
            Destroy(this);
    }
}
