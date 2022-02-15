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
    void Start()
    {
        Valider.interactable = false;
        Saisie.text = "";
        Reponse.text = "";
    }

    public void SaisieCode(int nombre)
    {
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
        }
        else
        {
            Reponse.text = "NON";
        }
    }

    public void SupprimerCode()
    {
        if (NbNombres > 0)
        {
            Valider.interactable = false;
            NbNombres--;
            Code = Code.Remove(Code.Length-1);
            Saisie.text = Saisie.text.Remove(Saisie.text.Length - 3);
        }
    }

}
