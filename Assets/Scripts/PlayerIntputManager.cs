using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerIntputManager : MonoBehaviour
{
    public void SetPlayerName(string _pname)
    {
        if (!string.IsNullOrEmpty(_pname))
        {
            PhotonNetwork.NickName = _pname;
        }
    }
}
