using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutSceneInicial : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mudarCena());
    }
    IEnumerator mudarCena()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

}