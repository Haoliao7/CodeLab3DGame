using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 force;

    float xForce;
    float yForce;
    float zForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xForce = Random.Range(-150, 150); // randomize this force
        yForce = Random.Range(550, 750);// randomize this force
        zForce = Random.Range(0,200);// randomize this force

        force = new Vector3(xForce, yForce, zForce);
        
        rb.AddForce(force); // add force to this object
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
