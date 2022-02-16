using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Manager_s;

    public float Temps;
    public float PenaliterTemps;
    public string CodeATrouver;
    public bool CodeTouve;
    [SerializeField] private GameObject[] Keys;
    public bool CanOpenDoor = false;
    public bool Fin = false;

    private bool ClesApparues = false;


    private void Awake()
    {
        Manager_s = this;
        CodeTouve = false;
    }
    private void Update()
    {
        if (CodeTouve && !ClesApparues)
        {
            ClesApparues = true;
            for (int i = 0; i < Keys.Length; i++)   // Faire apparaitre 5 clés dont la clé correcte permettant de sortir de la salle
                Keys[i].SetActive(true);
        }

        if (Temps <= 0) // Si temps écoulé
        {
            Debug.Log("PERDU Fin du temps");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Fin)    // Si la sortie a été trouvée
        {
            SceneManager.LoadScene(3);
        }
    }
}
