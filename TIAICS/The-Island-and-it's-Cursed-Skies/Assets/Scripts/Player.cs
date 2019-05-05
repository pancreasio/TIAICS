using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float xRotationSpeed;
    [SerializeField]
    float yRotationSpeed;
    [SerializeField]
    float zRotationSpeed;
    [SerializeField]
    float bulletSpawnPhase;
    [SerializeField]
    float roundsPerSecond;

    private float rotateX;
    private float rotateY;
    private float rotateZ;
    private float fireClock;
    private Rigidbody rigi;
    private GameObject cam;
    private string bulletException;

    public GameObject bullet;
    private void Start()
    {
        rigi = transform.GetComponent<Rigidbody>();
        cam = transform.GetComponentInChildren<Camera>().gameObject;
        fireClock = 0;
        bulletException= "Player";
    }

    private void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotateX = -Input.GetAxisRaw("Mouse Y");
        rotateY = -Input.GetAxisRaw("Horizontal");
        rotateZ =Input.GetAxis("Mouse X");

        fireClock += Time.deltaTime;
        if (fireClock >= 1/roundsPerSecond)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
            fireClock = 0;
        }
    }

    private void FixedUpdate()
    {
        rigi.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        transform.Rotate(new Vector3(rotateX*xRotationSpeed, rotateZ * zRotationSpeed,rotateY*yRotationSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "PlayerBullet")
        {
            Destroy(this.gameObject);
        }
        
    }

    private void Fire()
    {
        GameObject fireBullet = Instantiate(bullet, transform.position + transform.forward * bulletSpawnPhase, transform.rotation);
        fireBullet.tag = "PlayerBullet";
        fireBullet.GetComponent<Bullet>().exception = bulletException;
    }
}
