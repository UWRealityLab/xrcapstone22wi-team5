using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractor))]
public class GetInfo : MonoBehaviour
{
    [SerializeField] GameObject text;

    XRBaseInteractor baseInteractor;

    protected void OnEnable()
    {
        baseInteractor = GetComponent<XRBaseInteractor>();
        baseInteractor.hoverEntered.AddListener(OnHoverEntered);
    }

    protected void OnDisable()
    {
        baseInteractor.hoverEntered.RemoveListener(OnHoverEntered);
    }

    protected virtual void OnHoverEntered(HoverEnterEventArgs args)
    {
        // get canvas text from left hand controller
        // text = args.interactorObject.transform.gameObject.transform.parent.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        text.GetComponent<TextInformation>().UpdateSelected(args.interactableObject.transform.gameObject);
        //args.interactorObject.transform.gameObject.transform.parent.GetComponentInChildren<TextInformation>()
    }
}
