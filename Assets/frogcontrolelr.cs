using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frogcontrolelr : MonoBehaviour
{
    public Vector3 checkpoint;

    public Rigidbody body;
    public float power;
    public float torque;
    public float jumpPower;
    public Camera cam;
    public Transform tracker;
    public Collider collider;
    public float jumpCharge;
    public Slider slider;

    public  AudioClip[] sounds;
    public AudioSource audiosauce;
    public AudioSource audioConcrete;  

    // Start is called before the first frame update
    float rotation;
    void Start()
    {
        checkpoint = transform.position;

        slider.minValue = .5f;
        slider.maxValue = 2f;

    }
    private float map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
    public void respawn()
    {
        body.MovePosition(checkpoint);
        body.rotation = Quaternion.Euler(new Vector3(0, 1, 0));
        body.velocity = Vector3.zero;
        //doit
        audiosauce.PlayOneShot(sounds[0]);

    }
    public float velocity;
    // Update is called once per frame
    void Update()
    {
        var axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(grounded && !audioConcrete.isPlaying)
        {
            audioConcrete.Play();
        }
        else if(!grounded)
        {
            audioConcrete.Pause();
        }

        audioConcrete.volume = map(  body.velocity.magnitude, 0, 7, 0,1) + Mathf.Abs( axis.x / 4f);

        transform.rotation =
            Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, axis.x * torque * (grounded ? 1f : .5f) ));

        body.AddForce((transform.up * -axis.y * power * (grounded ? 1f : .1f) ), ForceMode.Force);

        if (!grounded)
        {
            body.AddForce((transform.right * axis.x * power * .8f) + (-transform.up * axis.y * power * .8f) , ForceMode.Force);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpCharge = .5f;
        }
        if (Input.GetButton("Jump") && grounded)
        {
            jumpCharge += .02f;
        }
        if (grounded && (jumpCharge > 2f || Input.GetButtonUp("Jump")))
        {
            body.AddForce((transform.forward - transform.up) * jumpPower * jumpCharge, ForceMode.Impulse );
            jumpCharge = 0;
            audiosauce.PlayOneShot(sounds[1]);
        }

        cam.transform.position = Vector3.Lerp(
            cam.transform.position, transform.position - cam.transform.forward + Vector3.up * .5f + transform.up, .1f);

        var temp = cam.transform.rotation;
        cam.transform.LookAt(transform);

        cam.transform.rotation = Quaternion.Lerp(temp, cam.transform.rotation, .5f);
        var euler = cam.transform.rotation.eulerAngles;

        if (Input.GetKeyDown(KeyCode.R))
        {
            body.AddForceAtPosition(Vector3.up * 1.1f, transform.position + new Vector3(.5f, -.5f, .1f), ForceMode.Impulse);
        }

        if(transform.position.y < 4f)
        {
            respawn();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            audiosauce.PlayOneShot(sounds[2]);
        }

        slider.value = jumpCharge;
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            checkpoint = other.gameObject.transform.position;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bonker")
        {
            audiosauce.PlayOneShot(sounds[Random.Range(3, 7)]);
        }
        if (collision.gameObject.name == "Terrain")
        {
            //respawn();
        }
        if (collision.gameObject.tag == "bullet")
        {
            audiosauce.PlayOneShot(sounds[7]);
        }
        if (collision.gameObject.tag == "sphere")
        {
            audiosauce.PlayOneShot(sounds[8],.1f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
    bool grounded;

    
}
