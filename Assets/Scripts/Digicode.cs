using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Digicode : MonoBehaviour
{
    [SerializeField] private Button Valider;
    [SerializeField] private Text Saisie;   // Texte pour que le joueur sache ce qu'il a saisie comme code
    [SerializeField] private Text Reponse;  // Texte pour indiquer au joueur si le code est correct ou non
    private string Code = "";
    private int NbNombres = 0;

    // Sons
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Touche;  // Son à l'appui des touches
    [SerializeField] private AudioClip Erreur;  // Son lorsque le code est incorrect
    [SerializeField] private AudioClip Correct; // Son lorsque le code est correct

    void Start()
    {
        Valider.interactable = false;   // Impossible de valider dès le début puisqu'il n'y a pas 3 chiffres de rentrés
        Saisie.text = "";
        Reponse.text = "";
    }

    public void SaisieCode(int nombre)  // A l'appui d'une touche
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(Touche);
        if (NbNombres < 3)  // S'il y a moins de trois chiffres de saisie
        {
            Valider.interactable = false;   // On ne peut toujours pas valider le code
            NbNombres++;
            Code += nombre.ToString();
            Saisie.text += $" {nombre.ToString()} ";
        }

        if (NbNombres >=3)  // S'il y a trois chiffres de saisie, la touche valider devient accessible
        {
            Valider.interactable = true;
        }
    }

    public void VerifierCode()
    {
        if(Code == Manager.Manager_s.CodeATrouver)  // Si le code est correct
        {
            Reponse.text = "CODE CORRECT";
            audioSource.volume = 1;
            audioSource.PlayOneShot(Correct);   // On lance le son de code correct
            Manager.Manager_s.CodeTouve = true;     // On indique au manager que la code a été trouvé
        }
        else    // Si le code est incorrect
        {
            Reponse.text = "CODE INCORRECT";
            audioSource.volume = 0.3f;
            audioSource.PlayOneShot(Erreur);    // On lance le son de code incorrect
            Manager.Manager_s.Temps -= Manager.Manager_s.PenaliterTemps;    // On met une pénalité de temps au joueur
        }
    }

    public void SupprimerCode() // Lorsqu'on veut supprimer un chiffre 
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(Touche);

        if (NbNombres > 0)  // Tant qu'il y a encore des chiffres à supprimer, on les retire
        {
            Valider.interactable = false;
            NbNombres--;
            Code = Code.Remove(Code.Length-1);
            Saisie.text = Saisie.text.Remove(Saisie.text.Length - 3);
        }
    }

}
