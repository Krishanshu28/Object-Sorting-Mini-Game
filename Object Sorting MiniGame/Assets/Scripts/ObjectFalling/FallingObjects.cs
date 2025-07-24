using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    void OnEnable()
    {
        // if (GameManager.Instance != null && GameManager.Instance.gameOver )
        // {
        //     // Stop everything
        //     GetComponent<Rigidbody>().useGravity = false;
        //     GetComponent<Rigidbody>().velocity = Vector3.zero;
        //     return;
        // }
        
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.down * Random.Range(0.2f, 0.3f), ForceMode.VelocityChange);
    }
    void Update() {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
