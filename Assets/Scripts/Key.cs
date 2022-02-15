using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key : MonoBehaviour
{
    public void OpenDoor(SelectEnterEventArgs args)
    {
        GameObject door = args.interactableObject.transform.gameObject;
        print(this.name);
        this.transform.Rotate(new Vector3(1, 0, 0), -90);
    }
}