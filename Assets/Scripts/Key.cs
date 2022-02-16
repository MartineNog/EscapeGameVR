using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip GoodKey;     // Son lorsque la bonne clé a été mise dans la serrure
    [SerializeField] private AudioClip FalseKey;    // Son lorsque la mauvaise clé a été mise dans la serrure
    [SerializeField] private AudioClip Door;        // Son lorsque la porte s'ouvre


    public void OpenDoor(SelectEnterEventArgs args) // Lorsqu'une clé rentre dans la serrure
    {  
        if (args.interactableObject.transform.name == "GoodKey")    // S'il s'agit de la bonne clé
        {
            Manager.Manager_s.CanOpenDoor = true;   // On indique au manager que la porte peut s'ouvrir
            audioSource.PlayOneShot(GoodKey);       // On lance le son associé
        }
        else    // S'il s'agit de la mauvaise clé
        {
            audioSource.PlayOneShot(FalseKey);  // On lance le son associé
                
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;    // On enlève la fonction d'objet interactable pour qu'il ne soit plus lié à la serrure
            args.interactableObject.transform.position= new Vector3(4.65f, 1.21f, -2.391f); // On déplace la clé pour qu'elle puisse tomber
            StartCoroutine(Wait(args.interactableObject.transform.gameObject));     // On laisse passer un peu de temps pour laisser la clé tomber avant de la remettre interactable. 
        } 
    }

    public void GoAway(SelectEnterEventArgs args)   // Lorsqu'on appui sur la poigné de porte
    {
        if (Manager.Manager_s.CanOpenDoor)  // Si la porte a bien été dévérouillée
        {
            audioSource.PlayOneShot(Door);  // On lance le son associé
            StartCoroutine(DoorIsOpenning(this.transform.gameObject)); // On lance l'animation de la porte ouvrante
            Manager.Manager_s.CanOpenDoor = false;  // On indique au manager que la porte ne peut plus être ouverte
        }
    }

    IEnumerator DoorIsOpenning(GameObject door)
    {
        for (int i = 0; i < 90; i++)    // Faire tourner la porte pour qu'elle puisse s'ouvrir
        {
            door.transform.Rotate(new Vector3(0, 1, 0), -1f);
            yield return new WaitForEndOfFrame();
        }
        Manager.Manager_s.IsOpen = true;    // On indique au manager que la porte a bien été ouverte
    }

    IEnumerator Wait(GameObject key)
    {
        // On laisse passer un peu de temps pour laisser la clé tomber avant de la remettre interactable. 
        yield return new WaitForSeconds(0.5f);
        key.GetComponent<XRGrabInteractable>().enabled = true;
    }
}