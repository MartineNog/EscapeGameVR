using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class EndGame : MonoBehaviour
{
    public void TheEnd(SelectEnterEventArgs args)
    {
        Manager.Manager_s.Fin = true;
    }
}
