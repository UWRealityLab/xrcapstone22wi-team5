using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class BackToMenu : MonoBehaviour
{
    public string scene;

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = false;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void DisconnectClient()
    {
        Debug.Log("Disconnecting Photon.");
        PhotonNetwork.Disconnect();
    }
}