using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static Player Instance;
    public Rigidbody2D myBody;
    public BoxCollider2D myCollider;
    public Animator myAnim;
    public float horizontalInput, speed;
    private string currentState;
    public GameObject baldePos;
    public GameObject baldePos2;
    public bool comBalde;
    public bool playerIsClose,baldeEntregue;
    public GameObject painelDialogo;
    public GameObject balde;
    public GameObject cansaso;
    public bool negao, enterro, morte, recife;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueControler.Instance.onDialogue)
        {
            return;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Animations();
        myBody.velocity = new Vector2(horizontalInput * speed, myBody.velocity.y);
    }

    public void Animations()
    {
        if (horizontalInput != 0 && comBalde == false)
        {
            ChangeAnimationState("Running");
        }
        if (horizontalInput == 0)
        {
            ChangeAnimationState("Idle");
        }
        if (horizontalInput != 0 && comBalde == true)
            ChangeAnimationState("Walk");
        if (horizontalInput == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (horizontalInput == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;

        myAnim.Play(newState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balde"))
        {
            collision.gameObject.transform.SetParent(baldePos.transform);
            collision.gameObject.transform.position = baldePos.transform.position;
            speed = speed / 3;
            comBalde = true;
            balde = collision.gameObject;
        }

        if (collision.CompareTag("idosa"))
        { 
            if (balde != null)
            {
                balde.GetComponent<BoxCollider2D>().enabled = false;
                balde.transform.parent = null;
                balde.transform.position = baldePos2.transform.position;
                comBalde = false;
                baldeEntregue = true;
                speed = 5;
            }
        }
        if (collision.CompareTag("Portao"))
        {
            playerIsClose = true;
            if (baldeEntregue == true)
            SceneManager.LoadScene(4);
        }

        if(collision.CompareTag("PortaoFinal"))
        {
            SceneManager.LoadScene(6);
        }

        if(collision.CompareTag("Cansaso"))
        {
            speed = speed - 0.5f;
            if(speed == 0.5f)
            {
                SceneManager.LoadScene(5);
            }

        }

        if (collision.CompareTag("portMorte"))
        {
            SceneManager.LoadScene(5);
        }
        if (collision.CompareTag("Negao"))
        {
            negao = true;
        }
        if (collision.CompareTag("Enterro"))
        {
            enterro = true;
            DialogueControler.Instance.transform.parent = null;
            DialogueControler.Instance.transform.position = collision.gameObject.transform.position;
        }

        if (collision.CompareTag("Morte"))
        {
            morte = true;
            DialogueControler.Instance.transform.parent = null;
            DialogueControler.Instance.transform.position = collision.gameObject.transform.position;
        }

        if (collision.CompareTag("Recife"))
        {
            recife = true;
            DialogueControler.Instance.transform.parent = null;
            DialogueControler.Instance.transform.position = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Negao"))
        {
            negao = false;
        }
        if (collision.CompareTag("Enterro"))
        {
            enterro = false;
        }
        if (collision.CompareTag("Morte"))
        {
            morte = false;
        }
        if (collision.CompareTag("Recife"))
        {
            recife = false;
        }
    }

}
