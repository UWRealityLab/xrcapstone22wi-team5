using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMaster : MonoBehaviour
{
    private bool isWait;
    public MeshRenderer lightMesh;
    public Light pointLight;
    public Material matGreenOn;
    public Material matRedOn;
    public Material matOff;
    public bool hasNewOrder;
    public GameManager gm;

    private AudioSource a = null;
    public AudioClip dispenseSound = null;

    void Start()
    {
        isWait = false;
        a = GetComponent<AudioSource>();
    }

    public void PlayTicketSound() {
        a.PlayOneShot(dispenseSound);
    }

    public IEnumerator printNewTicket()
    {
        if (isWait)
            yield break;

        isWait = true;
        turnRedLighOn();
        gm.RedrawAllOrders();
        yield return new WaitForSeconds(2);
        turnLighOff();
        isWait = false;
        yield break;
    }

    public IEnumerator reprintTicket()
    {
        if (isWait)
            yield break;

        isWait = true;
        turnRedLighOn();
        gm.RedrawLastOrder();
        yield return new WaitForSeconds(2);
        turnLighOff();
        isWait = false;
        yield break;
    }

    void Update()
    {
        if (isWait)
            return;

        if (gm.canMakeMore())
        {
            turnGreenLighOn();
        }
        else
        {
            turnLighOff();
        }

    }

    private void turnGreenLighOn()
    {
        lightMesh.material = matGreenOn;
        pointLight.enabled = true;
    }

    private void turnRedLighOn()
    {
        lightMesh.material = matRedOn;
        pointLight.enabled = true;
    }

    private void turnLighOff()
    {
        lightMesh.material = matOff;
        pointLight.enabled = false;
    }
}
