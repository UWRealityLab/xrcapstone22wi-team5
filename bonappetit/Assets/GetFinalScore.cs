using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class GetFinalScore : MonoBehaviourPunCallbacks
{
    private int finalScore;
    private TMP_Text tm;
    private PhotonView photonView;
    private GameObject textGo;

    // Start is called before the first frame update
    void Start()
    {
        if (tm == null) //wenn textmesh
        {
            textGo = gameObject.GetComponentInChildren<TMP_Text>().gameObject;
            tm = textGo.GetComponent<TMP_Text>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = finalScore.ToString();
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey("score")) {
            finalScore = (int) propertiesThatChanged["score"];
        }
    }
}
