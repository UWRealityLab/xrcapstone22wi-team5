using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class Knob : MonoBehaviour, IPunObservable
{
    [SerializeField]
    public int val = 0; // 0 - numSettings
    public int numSettings;
    public IndicatorLight greenLight;
    public IndicatorLight redLight;

    public AudioClip on = null;

    public AudioClip off = null;

    private AudioSource a;

    public readonly string[] labels4 = {"Off", "Low", "Medium", "High"};
    public readonly string[] labels2 = {"Off", "On"};


    // Start is called before the first frame update
    void Start()
    {
    if (on != null) {
        a = GetComponent<AudioSource>();
        if (a == null) {
            a = gameObject.AddComponent<AudioSource>();
        }
    }
    if (greenLight != null && redLight != null) {
        redLight.on = true;
        greenLight.on = false;
    }
    }

    public void RotateKnob()
    {
        float rotateDegrees = 360f / numSettings;
        transform.Rotate(0f, 0f, rotateDegrees);
        if (val == numSettings - 1) {
            a.PlayOneShot(off);
            val = 0;
            if (greenLight != null && redLight != null) {
                greenLight.on = false;
                redLight.on = true;
            }
        } else {
            val++;
            a.PlayOneShot(on);
            if (greenLight != null && redLight != null) {
                redLight.on = false;
                greenLight.on = true;
            }
        }
    }

    // returns a label for the current setting of the knob
    public string getLabel() {
        if (numSettings == 4) {
            return labels4[val];
        } else if (numSettings == 2) {
            return labels2[val];
        }

        return val.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(val);
        }
        else
        {
            val = (int)stream.ReceiveNext();
        }
    }
}
