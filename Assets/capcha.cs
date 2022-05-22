using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capcha : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject screen;
    public Rigidbody body;
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            body.useGravity = true;
            var sbody = screen.GetComponent<Rigidbody>();
            sbody.isKinematic = false;
            sbody.useGravity = true;
            sbody.AddForceAtPosition(Random.insideUnitSphere * 10f, transform.position, ForceMode.Impulse);
            source.PlayOneShot(source.clip);
        }
    }
}
