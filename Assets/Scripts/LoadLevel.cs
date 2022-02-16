using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour
{

    public int sceneIndex;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()  // A l'appui du bouton reset
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);  // On recharge la scène
    }
}
