using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using Photon.Pun;

public class PhotonThowableObject : PhotonGrabbableObject
{
    private Transform trackingSpace;

    public throwEvent throwE;
    public grabEvent grabE;

    [System.Serializable]
    public class throwEvent : UnityEvent<Vector3> { }

    [System.Serializable]
    public class grabEvent : UnityEvent<Vector3> { }

    private void Start()
    {
        GameObject trackingSpaceObj = GameObject.Find("TrackingSpace");
        if (trackingSpaceObj)
            trackingSpace = trackingSpaceObj.transform;

        if (throwE == null)
        {
            throwE = new throwEvent();
        }

        if (grabE == null)
        {
            grabE = new grabEvent();
        }
    }

    override public void OnPointerEventRaised(PointerEvent pointerEvent)
    {
        if (!this.GetComponent<PhotonView>().IsMine) {
            SampleController.Instance.Log("This is not mine!");
            return;
        }    
        switch (pointerEvent.Type)
        {
            case PointerEventType.Select:
                if (_grabbable.SelectingPointsCount == 1)
                {
                    SampleController.Instance.Log("Grabbable object grabbed");

                    TransferOwnershipToLocalPlayer();

                    grabE.Invoke(Vector3.zero);
                }
                break;
            case PointerEventType.Unselect:
                if (_grabbable.SelectingPointsCount == 0)
                {
                    SampleController.Instance.Log("Grabbable object ungrabbed");

                    if (trackingSpace != null)
                    {
                        Rigidbody objectRigidbody = GetComponent<Rigidbody>();

                        Vector3 vRightVelocity =
                            trackingSpace.rotation
                            * OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                        Vector3 vLeftVelocity =
                            trackingSpace.rotation
                            * OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);

                        if (vRightVelocity.magnitude > vLeftVelocity.magnitude)
                        {
                            objectRigidbody.velocity = vRightVelocity;
                            //objectRigidbody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
                            throwE.Invoke(
                                OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)
                            );
                        }
                        else
                        {
                            objectRigidbody.velocity = vLeftVelocity;
                            //objectRigidbody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch);
                            throwE.Invoke(
                                OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)
                            );
                        }
                    }
                }
                break;
        }
    }
}
