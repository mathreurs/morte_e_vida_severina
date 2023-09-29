using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negoes : MonoBehaviour
{
    public float horizontalInput, speed;
    public Rigidbody2D myBody;
    // Start is called before the first frame update

    void Start()
    {
        myBody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueControler.Instance.onDialogue)
        {
            speed = 0;
        }
        else
        {
            speed = -1;
        }
        myBody.velocity = new Vector2(speed, myBody.velocity.y); 
    }
}
