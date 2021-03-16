using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
   


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Le start de photon");
    }

   


    //connection au lobby de jeu
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster de photon");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby de photon");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom de photon");
        PhotonNetwork.Instantiate(PersonnageCreation.instance.personnageChoix.name, new Vector2(Random.Range(-8f, 8f), transform.position.y), Quaternion.identity);
        //PhotonNetwork.Instantiate("Bandit", new Vector2(Random.Range(-8f, 8f), transform.position.y), Quaternion.identity);
    }

}
