using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnigmeBtn : MonoBehaviour
{
    [SerializeField] private Text TextEnigme;
    public void mettreText(string text) // A l'appui du bouton d'énigme
    {
        TextEnigme.text = text;
    }
}
