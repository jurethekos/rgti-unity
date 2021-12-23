using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(1, 50)]
    public float torque = 40.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float ha = Input.GetAxis("Horizontal");
        float va = Input.GetAxis("Vertical");

        Debug.Log(Vector3.forward);
        rb.AddTorque(Vector3.forward * ha * -this.torque, ForceMode.Acceleration);
        rb.AddTorque(Vector3.right * va * this.torque, ForceMode.Acceleration);
    }
}
