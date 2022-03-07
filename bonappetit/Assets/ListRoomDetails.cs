using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ListRoomDetails : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI difficulty;
    public TextMeshProUGUI time;
    public TextMeshProUGUI turn;
    // Start is called before the first frame update
    void Start()
    {
        // if (PhotonNetwork.CurrentRoom != null) {
        //     ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
        //     if(!ht.ContainsKey("difficulty")){
        //         ht["difficulty"] = "Beginner";
        //     }
        //     if(!ht.ContainsKey("time")){
        //         ht["time"] = "4:00";
        //     }
        //     if(!ht.ContainsKey("turnOption")){
        //         ht["turnOption"] = 0;
        //     }
        //     PhotonNetwork.CurrentRoom.SetCustomProperties(ht);
        // }  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom != null) {
            ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
            if(!ht.ContainsKey("difficulty")){
                ht["difficulty"] = "Beginner";
            }
            if(!ht.ContainsKey("time")){
                ht["time"] = "4:00";
            }
            if(!ht.ContainsKey("turnOption")){
                ht["turnOption"] = 0;
            }

            level.text = "Map Selected:  " + "Map Name";
            difficulty.text = "Difficulty: " + (string)ht["difficulty"];
            time.text = "Time: " + (string)ht["time"] + " mins";
            int val = (int) ht["turnOption"];
            if (val == 1){
                turn.text = "Turn Type: Snap";
            }else{
                turn.text = "Turn Type: Continuous";
            }
            PhotonNetwork.CurrentRoom.SetCustomProperties(ht);
        }
    }
}
