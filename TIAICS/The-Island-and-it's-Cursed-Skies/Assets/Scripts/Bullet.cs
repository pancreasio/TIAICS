using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float activeClock;
    private Rigidbody rigi;

    public float speed;
    public float activeTime;
    public int damage;
    public string exception;
    public delegate void CollisionAction(int damage);
    CollisionAction collisionAction;

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
        if (other.tag != exception)
        {
            Debug.Log("exc ");
            Debug.Log("trig ");
            if (collisionAction != null)
            {
                collisionAction(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
