using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using System;

public class SelectTurnProvider : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject test;
    void Start()
    {
        var continuousTurn = test.GetComponent<ActionBasedContinuousTurnProvider>();
        var snapTurn = test.GetComponent<ActionBasedSnapTurnProvider>();
        if (PhotonNetwork.CurrentRoom != null) {
            ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
            if(!ht.ContainsKey("turnOption")){
                continuousTurn.enabled = true;
                snapTurn.enabled = false;
            }else{
                int val = (int) ht["turnOption"];
                Debug.Log("slider value: " + val);
                if(val == 1){
                    continuousTurn.enabled = false;
                    snapTurn.enabled = true;
                }else{
                    continuousTurn.enabled = true;
                    snapTurn.enabled = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
