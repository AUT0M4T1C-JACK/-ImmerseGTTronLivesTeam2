﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPassthrough : MonoBehaviour
{
    public MeshRenderer mesh;
    private Material mat;
    public Transform head, left, right;

    public void Init(Transform head, Transform left, Transform right)
    {
        this.head = head;
        this.left = left;
        this.right = right;
    }

    private void Start()
    {
        transform.SetParent(Camera.main.transform);
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        mat = mesh.material;
    }

    private void Update()
    {
        Transform target = head;
        if(target == null || !CoLocatedPassthroughManager.Instance.directional)
        {
            //set all values to 0;
            mat.SetFloat("_MaskActivationRadians", 0);
            return;
        }
        if(Vector3.Distance(left.position, transform.position) < Vector3.Distance(target.position, transform.position))
        {
            target = left;
        }
        if(Vector3.Distance(right.position, transform.position) < Vector3.Distance(target.position, transform.position))
        {
            target = right;
        }
        Vector3 dir = target.position - transform.position;
        //dir for testing purposes
        //Vector3 dir = Vector3.up * 1.5f - transform.position;
        float forward = Vector3.Angle(dir.normalized, transform.forward);
        dir = transform.InverseTransformDirection(dir);
        float dist = dir.magnitude;
        forward = Mathf.Clamp01((forward - CoLocatedPassthroughManager.Instance.centerAngle) / CoLocatedPassthroughManager.Instance.wideAngle);
        dist = Mathf.Clamp01(CoLocatedPassthroughManager.Instance.farDistance / dist - CoLocatedPassthroughManager.Instance.nearDistance) * forward * CoLocatedPassthroughManager.Instance.multiplier;
        mat.SetVector("_MaskDirection", dir.normalized);
        mat.SetFloat("_MaskActivationRadians", dist);
        mat.SetFloat("_MaskFeatherRadians", CoLocatedPassthroughManager.Instance.feather);
    }
}
