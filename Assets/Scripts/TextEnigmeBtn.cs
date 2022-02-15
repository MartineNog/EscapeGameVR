using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnigmeBtn : MonoBehaviour
{
    public Text TextEnigme;
    public void mettreText(string text)
    {
        TextEnigme.text = text;
    }
}
