using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestPlayerTurn : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform m_BlueGuti1;
    
    // Start is called before the first frame update
    void Start()
    {
        // if (photonView.IsMine)
        // {
        //     //photonView.Owner.NickName;
        //     //enable script 
        //     // set player UI 
        // }
        // else
        // {
        //     //disable script
        //     // set 2nd player UI
        // }
        
        //PlayerTurnEvent.Player1Turn();
    }

    public void Player1Turn()
    {
        PlayerTurnEvent.Player1Turn();
    }

    public void Player2Turn()
    {
        PlayerTurnEvent.Player2Turn();
    }
    
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += EventData;
    }

   
    public void EventData(EventData eventData)
    {
        print("event data" + eventData.Code);
        foreach (KeyValuePair<byte,object> pair in eventData.Parameters)
        {
            print(pair.Key + " => " + pair.Value);
        }
    }

    /*
     * photonView.IsMine
     *    - RPC("TakeDamage", RPCTarget.All, value)
     */

    private void Update()
    {
        // check if not to move other players guti
        // if photonViewIsMine
        // if (Input.GetKeyDown(KeyCode.S) && m_BlueGuti1.GetComponent<PhotonView>().IsMine)
        // {
        //     m_BlueGuti1.GetComponent<PhotonView>().RPC("MoveGuti", RpcTarget.All);
        // }
    }//end 
}
