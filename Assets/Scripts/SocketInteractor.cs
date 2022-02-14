using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteractor : MonoBehaviour
{
    public void OnSelect(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.name);
    }
}
