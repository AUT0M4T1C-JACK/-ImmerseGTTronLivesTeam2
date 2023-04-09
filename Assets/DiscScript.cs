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

    public ParticleSystem particles;

    private float startingTime;

    public float distance;
    public int bounceCount;

    [SerializeField]
    private AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        am = GetComponentInChildren<AudioManager>();
        thrown = false;
        returning = false;
        bounceCount = 0;
        this.GetComponent<PhotonThowableObject>().throwE.AddListener(Throw);
        this.GetComponent<PhotonThowableObject>().grabE.AddListener(Catch);
        am.PlayOnSFX();
        am.PlayIdleSFX();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (returning)
        {
            targetDirection = targetVector - transform.position; // Save direction // Normalize target direction vector

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
            am.PlayThrowSFX();
        }
    }

    public void Catch(Vector3 handPos)
    {
        returning = false;
        thrown = false;
        bounceCount = 0;
        //am.Play
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DiskPlane"))
        {
            returning = false;
            thrown = false;
            rb.velocity = Vector3.zero;
            this.transform.position = Camera.main.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            particles.Play();
            bounceCount++;
            am.PlayBounceSFX();
        }

        if (bounceCount == 4)
        {
            returning = false;
            thrown = false;
            rb.velocity = Vector3.zero;
            this.transform.position =
                Camera.main.transform.position + Camera.main.transform.forward * 0.4f;
        }
    }
}
