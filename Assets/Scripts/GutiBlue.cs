using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using DG.Tweening;

public class GutiBlue : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform m_GutiEndPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [PunRPC]
    public void MoveGuti()
    {
        transform.DOLocalMove(m_GutiEndPos.position, 0.5f).SetEase(Ease.Flash);
        print("moved guti");
    }
    
}
