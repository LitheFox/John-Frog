using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject log;
    Vector3 start;
    public float breadth = 1;
    public float speed = 1;
    float offset;
    void Start()
    {
        start = transform.position;
        offset = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        log.transform.LookAt(transform);

        var t = Mathf.Sin( Time.time *2f * speed + offset) * .5f * breadth - (Mathf.PI /2f);
        Vector2 vec = new Vector2(Mathf.Cos(t), Mathf.Sin(t));

        log.transform.position = start + new Vector3(vec.x,vec.y,0) * 5f;
    }
}
