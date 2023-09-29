using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutScene2 : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mudarCena());
    }
    IEnumerator mudarCena()
    {

        yield return new WaitForSeconds(18);
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

}
