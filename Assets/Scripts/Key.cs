using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Serrure;
    [SerializeField] private AudioClip Door;

    [SerializeField] private bool CanOpen = true;
    [SerializeField] private bool IsOpen = false;

    public void OpenDoor(SelectEnterEventArgs args)
    {
        GameObject door = args.interactableObject.transform.gameObject;
        print(this.name);
        if (CanOpen)
        {
            IsOpen = true;
            CanOpen = false;
            audioSource.PlayOneShot(Serrure);
        }
        
    }

    public void GoAway(SelectEnterEventArgs args)
    {
        if (IsOpen)
        {
            audioSource.PlayOneShot(Door);
            StartCoroutine(DoorIsOpenning(this.transform.gameObject));
            IsOpen = false;
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

}