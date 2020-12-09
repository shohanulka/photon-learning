using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine;

public class PlayerTurnEvent
{
    public static void Player1Turn()
    {
        string turn = "Player 1";
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        PhotonNetwork.RaiseEvent(1, turn, raiseEventOptions, SendOptions.SendReliable);
    }
    
    public static void Player2Turn()
    {
        string turn = "Player 2";
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        PhotonNetwork.RaiseEvent(2, turn, raiseEventOptions, SendOptions.SendReliable);
    }
}
