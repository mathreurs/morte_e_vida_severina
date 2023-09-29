using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutSceneCena1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(mudarCena());
    }
    IEnumerator mudarCena()
    {

        yield return new WaitForSeconds(35);
       // SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
}
