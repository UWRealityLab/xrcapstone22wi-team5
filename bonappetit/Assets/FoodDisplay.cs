using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Realtime;

public class FoodDisplay : MonoBehaviourPunCallbacks
{
    List<GameObject[]> highlightObjs;
    List<List<Color>> startColor;
    List<List<Renderer>> currRenders;
    Dictionary <int, bool> checkSelect = new Dictionary <int, bool> ();

    [SerializeField]
    private Material highlightMaterial;

    List<List<Material>> defaultMaterials;
    //int itemIdx = 0;

    readonly float blinkTime = 0.1f;
    float elapsed;


    // Start is called before the first frame update
    void Start()
    {
        highlightObjs = new List<GameObject[]>();
        highlightObjs.Add(new GameObject[] { GameObject.Find("Steak Frites") });
        highlightObjs.Add(new GameObject[] { GameObject.Find("Crab Cakes") });
        highlightObjs.Add(new GameObject[] { GameObject.Find("French Onion Soup") });
        highlightObjs.Add(new GameObject[] { GameObject.Find("Roast Chicken") });
        highlightObjs.Add(new GameObject[] { GameObject.Find("Table Bread") });
        

        startColor = new List<List<Color>>();
        currRenders = new List<List<Renderer>>();
        defaultMaterials = new List<List<Material>>();

        for(int itemIdx = 0; itemIdx < highlightObjs.Count; itemIdx++){
            foreach (var obj in highlightObjs[itemIdx])
            {
                if (obj == null)
                    continue;

                if (obj.GetComponent<Renderer>() != null)
                {
                    startColor.Add(new List<Color>(){obj.GetComponent<Renderer>().material.color});
                    currRenders.Add(new List<Renderer>(){obj.GetComponent<Renderer>()});
                    defaultMaterials.Add(new List<Material>(){obj.GetComponent<Renderer>().material});
                }

                Renderer[] renders = obj.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renders)
                {
                    startColor[itemIdx].Add(r.material.color);
                    currRenders[itemIdx].Add(r);
                    checkSelect[itemIdx] = true;
                    defaultMaterials[itemIdx].Add(r.material);
                }
            }
            
            elapsed = blinkTime;
        }

        ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
        ht["FoodDisplay"] = "00000";
        PhotonNetwork.CurrentRoom.SetCustomProperties(ht);
        InvokeRepeating("UpdateFood", 0.1f, 0.5f);
    }

    // Update is called once per frame
    void UpdateFood()
    {
        if (PhotonNetwork.CurrentRoom != null) {
            ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
            string val;
            if(!ht.ContainsKey("FoodDisplay")){
                ht["FoodDisplay"] = "00000";
                // if(PhotonNetwork.IsMasterClient){
                //     PhotonNetwork.CurrentRoom.SetCustomProperties(ht);
                // }
                val = "00000";
            }else{
                val = (string) ht["FoodDisplay"];
            }
            for(int i = 0; i < val.Length; i++){
                if(val[i] == '1'){
                    checkSelect[i] = false;
                }else{
                    checkSelect[i] = true;
                }
            }
         }
        Blink();
    }



    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        var interactorObj = args.interactorObject.transform.gameObject;
        //Debug.Log("Selected");    
    }

    void Blink()
    {
        elapsed += Time.deltaTime;
        for (int idx = 0; idx < startColor.Count; idx++)
        {
            if(checkSelect[idx]){
                for (int i = 0; i < startColor[idx].Count; i++){
                    //Color currentColor = Color.Lerp(startColor[idx][i], Color.yellow, Mathf.Cos(elapsed / blinkTime) * 0.7f + 0.3f);
                    //currRenders[idx][i].material.color = currentColor;
                    currRenders[idx][i].material = highlightMaterial;
                }
            }else{
                for (int i = 0; i < startColor[idx].Count; i++){
                    currRenders[idx][i].material = defaultMaterials[idx][i];
                }
            }
        }
    }


}
