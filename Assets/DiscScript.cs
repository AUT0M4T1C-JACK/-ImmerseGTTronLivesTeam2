using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscScript : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 throwDirection;
    private bool thrown;

    private float forceAmount = 4.5f;
    public bool returning;

    private Vector3 targetDirection;
    private float throwSpeed;

    public float throwForce = 15f;
    public Transform targetTransform;
    public Vector3 targetVector;

    private float startingTime;

    public float distance;

    public bool polling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrown = false;
        returning = false;
        this.GetComponent<PhotonThowableObject>().throwE.AddListener(Throw);
        this.GetComponent<PhotonThowableObject>().grabE.AddListener(Catch);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // distance = Vector3.Distance(targetVector, this.transform.position);
        // if (distance > 5 && polling)
        // {
        //     rb.velocity = Vector3.zero;
        //     polling = false;
        //     ReturnDisc();
        // }

        // if (rb.velocity != Vector3.zero)
        // {
        //     this.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        // }

        if (returning)
        {
            targetDirection = targetTransform.position - transform.position; // Save direction // Normalize target direction vector

            rb.AddForce(targetDirection.normalized * (rb.mass * throwSpeed) / 0.75f);
        }
    }

    public void ReturnDisc()
    {
        targetDirection = targetVector - this.transform.position;
        rb.velocity = targetDirection.normalized * throwSpeed;
    }

    public void Throw(Vector3 handPos)
    {
        if (!thrown)
        {
            throwSpeed = rb.velocity.magnitude;
            returning = true;
            thrown = true;
            targetVector = handPos;
            targetTransform = Camera.main.transform;
            startingTime = Time.time;
            polling = true;
            SampleController.Instance.Log(((rb.mass * throwSpeed) / 0.75f).ToString());
        }
    }

    public void Catch(Vector3 handPos)
    {
        returning = false;
        thrown = false;
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("DiskPlane")) {
            returning = false;
            thrown = false;
            rb.velocity = Vector3.zero;
            this.transform.position = Camera.main.transform.position;
        }
    }
}
