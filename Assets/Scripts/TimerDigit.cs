using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDigit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(chronos());
        Manager.Manager_s.Temps++;
    }
    IEnumerator chronos()
    {
        while ( Manager.Manager_s.Temps  > 0)
        {
            Manager.Manager_s.Temps--;
            yield return new WaitForSeconds(1f);
            GetComponent<Text> ().text = string.Format("{0:0}:{1:00}", Mathf.Floor(Manager.Manager_s.Temps / 60), Manager.Manager_s.Temps  % 60);
        }
    }
}
