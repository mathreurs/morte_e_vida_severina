using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class morteManager : MonoBehaviour
{
     [SerializeField] private string nomeDoLevelDeJogo;

    public void Morte()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
}
