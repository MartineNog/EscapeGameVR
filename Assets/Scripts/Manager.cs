using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Manager : MonoBehaviour
{
    public static Manager Manager_s;    // Création  du Singleton

    public float Temps;     // Temps restant
    public float PenaliterTemps;    // Pénalité de temps en cas de mauvais code du digitcode
    public string CodeATrouver; // Code a trouver pour le digitcode
    public bool CodeTouve;  // Indique si le joueur a trouvé ou non le code 
    [SerializeField] private GameObject[] Keys; // Les cinqs clés à instancier lorsque le code a été trouvé
    public bool CanOpenDoor = false;    //Indiquer si le joueur peut ouvrir la porte lorsque la bonne clé a été mise dans la serrure
    public bool IsOpen = false;    // Indiquer si le joueur a ouvert la pourte
    public GameObject PlateformExit;    // Plateforme finale
    public bool Fin = false;    // Indiquer si le joueur est sur la plaque de téléportation de fin de partie

    private bool ClesApparues = false;  // Savoir si les clés ont déjà été instanciées


    private void Awake()
    {
        Manager_s = this;   // Mise en place du Singleton
        CodeTouve = false;
        PlateformExit.GetComponent<TeleportationAnchor>().enabled = false;
    }
    private void Update()
    {
        if (CodeTouve && !ClesApparues) // Si le code a été trouvé et que les clés n'ont pas encore été instanciées 
        {
            ClesApparues = true;    // On indique que les clés sont apparues
            for (int i = 0; i < Keys.Length; i++)   // Faire apparaitre 5 clés dont la clé correcte permettant de sortir de la salle
                Keys[i].SetActive(true);
        }

        if (Temps <= 0) // Si temps écoulé
        {
            Debug.Log("PERDU Fin du temps");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // On charge la scène du GameOver
        }
        if (Fin)    // Si la sortie a été trouvée
        {
            SceneManager.LoadScene(3);  // On charge la scène du victoire
        }

        if(Keys[2].transform.position.y <= 0)   // Si la bonne clé est sortie de la zone de jeu
        {
            // On enlève le momentum de la clé
            Rigidbody rb = Keys[2].GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            
            // On la fait réapparaitre sur la table
            Keys[2].transform.position = new Vector3(2.73f, 2.05f, 2.28f);
        }

        if (IsOpen) // Si la porte est ouverte
            PlateformExit.GetComponent<TeleportationAnchor>().enabled = true;   // Réactiver la téléportation
    }
}
