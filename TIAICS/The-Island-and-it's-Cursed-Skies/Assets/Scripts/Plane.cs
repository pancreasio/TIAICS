using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float xRotationSpeed;
    [SerializeField]
    float zRotationSpeed;
    private float rotateX;
    private float rotateZ;
    private Rigidbody rigi;
    // Start is called before the first frame update
    private void Start()
    {
        rigi = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        rotateX = Input.GetAxis("Vertical");
        rotateZ =Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigi.AddForce(transform.up * -moveSpeed, ForceMode.Acceleration);
        transform.Rotate(new Vector3(rotateX*xRotationSpeed, rotateZ * zRotationSpeed,0));
    }
}
