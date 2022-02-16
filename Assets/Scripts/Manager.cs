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
    public bool IsOpen = false;
    //[SerializeField] private GameObject PlateformExit;
    public bool Fin = false;

    private bool ClesApparues = false;


    private void Awake()
    {
        Manager_s = this;
        CodeTouve = false;
        //PlateformExit.GetComponent<TeleportationAnchor>().enabled = false;
    }
    private void Update()
    {
        //print(PlateformExit.name);
        if (CodeTouve && !ClesApparues)
        {
            ClesApparues = true;
            for (int i = 0; i < Keys.Length; i++)   // Faire apparaitre 5 cl�s dont la cl� correcte permettant de sortir de la salle
                Keys[i].SetActive(true);
        }

        if (Temps <= 0) // Si temps �coul�
        {
            Debug.Log("PERDU Fin du temps");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Fin)    // Si la sortie a �t� trouv�e
        {
            SceneManager.LoadScene(3);
        }

        if(Keys[2].transform.position.y <= 0)
        {
            Keys[2].transform.position = new Vector3(2.73f, 2.05f, 2.28f);
        }

        /*if (IsOpen)
            PlateformExit.GetComponent<TeleportationAnchor>().enabled = true;*/
    }
}
