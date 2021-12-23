using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(1, 50)]
    public float torque = 15.0f;
    public Transform cam;
    public float jump = 5;
    private float jumpCooldown = 0.0f;
    [Range(1, 50)]
    public float maxVelocity = 15; //default = 7

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        float ha = Input.GetAxis("Horizontal");
        float va = Input.GetAxis("Vertical");
        rb.maxAngularVelocity = maxVelocity;

        rb.AddTorque(cam.forward * ha * -this.torque, ForceMode.Acceleration);
        rb.AddTorque(cam.right * va * this.torque, ForceMode.Acceleration);

        if(Input.GetButtonDown("Jump") && jumpCooldown <= 0){
            rb.velocity = rb.velocity + (Vector3.up * jump);
            jumpCooldown = 1;
        }
        if(jumpCooldown > 0){
            jumpCooldown -= Time.deltaTime;
        }
    }
}
