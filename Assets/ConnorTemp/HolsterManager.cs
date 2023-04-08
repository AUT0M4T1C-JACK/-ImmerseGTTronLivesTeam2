using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterManager : MonoBehaviour
{
    [SerializeField] public GameObject centerEyeAnchor;
    [SerializeField] private float rotationSpeed = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(centerEyeAnchor.transform.position.x, 
            centerEyeAnchor.transform.position.y, 
            centerEyeAnchor.transform.position.z);
        
        var rotationDifference = Mathf.Abs(centerEyeAnchor.transform.eulerAngles.y - transform.eulerAngles.y);
        var finalRotationSpeed = rotationSpeed;

        //if (rotationDifference > 60)

        var step = finalRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, centerEyeAnchor.transform.eulerAngles.y, 0), step);
    }
}
