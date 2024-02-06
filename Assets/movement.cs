using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 0f;

    private bool isInSlowZone = false;

    void Update()
    {
        float currentSpeed = isInSlowZone ? slowSpeed : normalSpeed;

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * currentSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlowZone"))
        {
            isInSlowZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlowZone"))
        {
            isInSlowZone = false;
        }
    }
}
