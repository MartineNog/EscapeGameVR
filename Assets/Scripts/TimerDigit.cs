using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDigit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(chronos());  // Démarrer le chronoTimer
        Manager.Manager_s.Temps++;  // Ajouter une seconde au chrono le temps de l'afficher
    }
    IEnumerator chronos()
    {
        while ( Manager.Manager_s.Temps  > 0)   // Tant qu'il reste du temps
        {
            Manager.Manager_s.Temps--;  // On le décrémente
            yield return new WaitForSeconds(1f);    // On attend une seconde
            GetComponent<Text> ().text = string.Format("{0:0}:{1:00}", Mathf.Floor(Manager.Manager_s.Temps / 60), Manager.Manager_s.Temps  % 60);   // On l'affiche au format minutes:seconde
        }
    }
}
