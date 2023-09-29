using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueControler : MonoBehaviour
{
    public static DialogueControler Instance;

    public GameObject dialoguePanel;
    public GameObject pressPanel, pressPanelNegao, pressPanelMorte, pressPanelEnterro, pressPanelRecife;
    public TMP_Text dialogueText;
    public string[] dialogue1, dialogue2, dialogue3, dialogue4, actualDialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    public bool onDialogue;
    public bool cont;
    public Image dialogueImage;
    public Sprite[] characterSprites;

    public GameObject desistir;
    public bool morte;
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && onDialogue == false)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                if (Player.Instance.baldeEntregue == true)
                {
                    actualDialogue = dialogue2;
                }
                else
                {
                    actualDialogue = dialogue1;
                }
                if (Player.Instance.negao == true)
                {
                    actualDialogue = dialogue1;
                    desistir.SetActive(false);
                }

                if (Player.Instance.enterro == true)
                {
                    actualDialogue = dialogue2;
                    desistir.SetActive(false);
                }

                if (Player.Instance.morte == true)
                {
                    actualDialogue = dialogue3;
                    desistir.SetActive(true);
                }
                if (Player.Instance.recife == true)
                {
                    actualDialogue = dialogue4;
                    desistir.SetActive(false);
                }

                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                onDialogue = true;
            }
        }
        if (onDialogue == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StopAllCoroutines();
                NextLine();
            }

        }
    }


    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        onDialogue = false;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        string nome = actualDialogue[index].Split(new char[] { ' ' })[0];
        switch (nome)
        {
            case "Severino":
                dialogueText.alignment = TextAlignmentOptions.TopLeft;
                dialogueText.enableAutoSizing = false;
                dialogueText.fontSize = 50;
                dialogueImage.gameObject.SetActive(true);
                dialogueImage.sprite = characterSprites[0];
                break;

            case "Idosa":
                dialogueImage.sprite = characterSprites[1];
                break;

            case "Severino.D":
                dialogueImage.sprite = characterSprites[2];
                break;

            case "Severino.M":
                dialogueImage.sprite = characterSprites[3];
                break;

            case "Morte":
                dialogueImage.sprite = characterSprites[4];
                break;

            case "RECIFE":
                dialogueImage.gameObject.SetActive(false);
                dialogueText.alignment = TextAlignmentOptions.MidlineLeft;
                dialogueText.enableAutoSizing = true;
                dialogueText.fontSizeMax = 300;
                break;
        }
        foreach (char letter in actualDialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        if (index < actualDialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            if (gameObject.tag == "idosa")
                pressPanel.SetActive(true);

            if (Player.Instance.negao == true)
                pressPanelNegao.SetActive(true);

            if (Player.Instance.enterro == true)
                pressPanelEnterro.SetActive(true);

            if (Player.Instance.morte == true)
                pressPanelMorte.SetActive(true);

            if (Player.Instance.recife == true)
                pressPanelRecife.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            if (gameObject.tag == "Idosa")
                pressPanel.SetActive(false);

            pressPanelNegao.SetActive(false);
            pressPanelMorte.SetActive(false);
            pressPanelEnterro.SetActive(false);
            ZeroText();
        }
    }


}
