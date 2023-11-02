using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{
    private Rigidbody rb;
    public float cannonForce;
    public float forwardForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * cannonForce + Vector3.forward * forwardForce, ForceMode.Impulse);
    }
}
