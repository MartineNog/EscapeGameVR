using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip GoodKey;
    [SerializeField] private AudioClip FalseKey;
    [SerializeField] private AudioClip Door;


    public void OpenDoor(SelectEnterEventArgs args)
    {
        GameObject door = args.interactableObject.transform.gameObject;
        print($"Objet : {args.interactableObject.transform.name}");
       
        if (args.interactableObject.transform.name == "GoodKey")
        {
        Manager.Manager_s.CanOpenDoor = true;
            audioSource.PlayOneShot(GoodKey);
        }
        else
        {
            print("MauvaiseCle");
            audioSource.PlayOneShot(FalseKey);
                
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            args.interactableObject.transform.position= new Vector3(4.65f, 1.21f, -2.391f);
            StartCoroutine(Wait(args.interactableObject.transform.gameObject));
        } 
    }

    public void GoAway(SelectEnterEventArgs args)
    {
        if (Manager.Manager_s.CanOpenDoor)
        {
            audioSource.PlayOneShot(Door);
            StartCoroutine(DoorIsOpenning(this.transform.gameObject));
            Manager.Manager_s.CanOpenDoor = false;
        }
    }

    IEnumerator DoorIsOpenning(GameObject door)
    {
        for (int i = 0; i < 90; i++)
        {
            door.transform.Rotate(new Vector3(0, 1, 0), -1f);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Wait(GameObject key)
    {
        yield return new WaitForSeconds(0.5f);
        key.GetComponent<XRGrabInteractable>().enabled = true;
    }
}