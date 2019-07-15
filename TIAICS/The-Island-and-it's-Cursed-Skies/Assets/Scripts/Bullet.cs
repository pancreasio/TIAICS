using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float activeClock;
    private Rigidbody rigi;

    public float speed, activeTime;
    public int damage;

    private void Start()
    {
        rigi = transform.GetComponent<Rigidbody>();
        activeClock = 0;
    }

    private void Update()
    {
        activeClock += Time.deltaTime;
        if (activeClock >= activeTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        rigi.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
