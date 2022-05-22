using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject bullet;
    public float range;
    public float power;
    public float cooldown;

    void Start()
    {
        StartCoroutine(shoot());

    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));

        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < range)
            {
                var bul = Instantiate(bullet, transform.position, transform.rotation);
                var b = bul.GetComponent<bullet>();
                b.vel = transform.forward * power;
                Debug.Log("shooting");
            }
            else
            {
                Debug.Log("no range");
            }
        }

        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            if (Vector3.Distance(transform.position, player.transform.position) < range)
            {
                transform.LookAt(player.transform);


            }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player = collision.gameObject;
        }
    }
}
