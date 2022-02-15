using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Digicode : MonoBehaviour
{
    [SerializeField] private Button Valider;
    [SerializeField] private Text Saisie;
    [SerializeField] private Text Reponse;
    [SerializeField] private string CodeATrouver;
    [SerializeField] private string Code = "";
    [SerializeField] private int NbNombres = 0;

    // Sons
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Touche;
    [SerializeField] private AudioClip Erreur;
    [SerializeField] private AudioClip Correct;

    // Clé
    [SerializeField] private GameObject[] Keys;
    void Start()
    {
        Valider.interactable = false;
        Saisie.text = "";
        Reponse.text = "";
    }

    public void SaisieCode(int nombre)
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(Touche);
        if (NbNombres < 3)
        {
            Valider.interactable = false;
            NbNombres++;
            Code += nombre.ToString();
            Saisie.text += $" {nombre.ToString()} ";
        }

        if (NbNombres >=3)
        {
            Valider.interactable = true;
        }
    }

    public void VerifierCode()
    {
        if(Code == CodeATrouver)
        {
            Reponse.text = "OUI";
            audioSource.volume = 1;
            audioSource.PlayOneShot(Correct);
            for (int i = 0; i < Keys.Length; i++)
                Keys[i].SetActive(true);
        }
        else
        {
            audioSource.volume = 0.3f;
            audioSource.PlayOneShot(Erreur);
            Reponse.text = "NON";
        }
    }

    public void SupprimerCode()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(Touche);

        if (NbNombres > 0)
        {
            Valider.interactable = false;
            NbNombres--;
            Code = Code.Remove(Code.Length-1);
            Saisie.text = Saisie.text.Remove(Saisie.text.Length - 3);
        }
    }

}
