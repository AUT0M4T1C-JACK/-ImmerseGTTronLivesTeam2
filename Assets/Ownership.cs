using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Ownership : MonoBehaviour
{
    public Player owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = PhotonNetwork.LocalPlayer;
    }
}
