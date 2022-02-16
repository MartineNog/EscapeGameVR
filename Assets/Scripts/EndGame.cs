using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class EndGame : MonoBehaviour
{
    public void TheEnd(SelectEnterEventArgs args)
    {
        if (Manager.Manager_s.IsOpen)   // Si la porte a bien été ouverte
            Manager.Manager_s.Fin = true;   // On indique que la partie peut être finie
    }
}
