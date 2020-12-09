using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //instantiated players
        if (PhotonNetwork.IsConnected)
        {
            //PhotonNetwork.Instantiate(new GameObject("Player 1"), Vector3.one, Quaternion.identity)
        }
    }

    #region photon callback

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.NickName);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
}
