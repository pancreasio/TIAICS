using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed, xRotationSpeed, yRotationSpeed, zRotationSpeed, bulletSpawnPhase, roundsPerSecond, dashSpeed;
    private float rotateX, rotateY, rotateZ, fireClock;
    private Rigidbody rigi;
    public GameObject bullet;
    public LevelManager levelManager;
    public Text altitudeText, speedText;
    public int HP;
    private bool dashing;

    private void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        rigi = GetComponent<Rigidbody>();
        fireClock = 0;
    }

    private void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (!dashing)
        {
            rotateX = -Input.GetAxisRaw("Mouse Y");
            rotateY = -Input.GetAxisRaw("Horizontal");
            rotateZ = Input.GetAxis("Mouse X");
        }
        else
        {
            rotateX = 0.0f;
            rotateY = 0.0f;
            rotateZ = 0.0f;
        }

        fireClock += Time.deltaTime;
        if (fireClock >= 1/roundsPerSecond)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
            fireClock = 0;
        }

        if (Input.GetMouseButton(1))
        {
            dashing = true;
        }
        else
        {
            dashing = false;
        }

        altitudeText.text = "Altitude: " + Mathf.Round(transform.position.y * 3).ToString() + "m";
        speedText.text = "Speed: " + Mathf.Round(rigi.velocity.magnitude*30).ToString() + " Km/h";
    }

    private void FixedUpdate()
    {
        rigi.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        if (dashing)
        {
            rigi.AddForce(transform.forward * dashSpeed, ForceMode.Acceleration);
        }
        transform.Rotate(new Vector3(rotateX*xRotationSpeed, rotateZ * zRotationSpeed,rotateY*yRotationSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Terrain")
        {
            levelManager.GameOver();
        }
        
    }

    private void Fire()
    {
        GameObject fireBullet = Instantiate(bullet, transform.position + transform.forward * bulletSpawnPhase, transform.rotation);
        fireBullet.tag = "PlayerBullet";
    }

    public void Damage(int damage)
    {
        HP -= damage;
    }
}
