using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu: MonoBehaviour

{
    public GameObject painelMenu, painelCreditos;
    public AudioSource jukebox;
    public AudioClip musica, efeito;
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;

    void start()
    {
        jukebox.Play();
    }
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }


    public void SairJogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }

public void MudarCreditos()
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(false);
        painelCreditos.SetActive(true);
    }
public void MudarMenu()
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
    }

}
