using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoueurReseau : MonoBehaviour
{
    public MonoBehaviour[] scripteAIgnorer;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var scripte in scripteAIgnorer)
            {
                scripte.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
