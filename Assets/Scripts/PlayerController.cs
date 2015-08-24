using UnityEngine;
using System.Collections;

public class PlayerController : Unit {

    public bool isSpirit;
    public bool canBeHuman;

    public GameObject playerBody;

	void Start () 
    {
        isSpirit = false;
        myBody = this.GetComponent<Rigidbody2D>();
        myRender = this.GetComponent<SpriteRenderer>();
	}
	
	void Update () 
    {
        CheckInput();

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerBody")
        {
            canBeHuman = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerBody")
        {
            canBeHuman = false;
        }
    }

    /// <summary>
    /// The player is able to leave his body as a spirit and solve puzzles.
    /// The spirit form will become the moving player unit while a body
    /// gameobject is left behind and must be reached to reenter the body.
    /// </summary>
    public void SwapForms()
    {
        if (GameController.control.player_isSpirit && canBeHuman == true)
        {
            playerBody.SetActive(false);
            GameController.control.player_isSpirit = false;
            myBody.gravityScale = 1.0f;
            myRender.color = Color.white;
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }
        else if (!GameController.control.player_isSpirit)
        {
            playerBody.transform.position = this.gameObject.transform.position;
            playerBody.SetActive(true);
            GameController.control.player_isSpirit = true;
            myBody.gravityScale = 0.0f;
            myRender.color = Color.blue;
            Physics2D.IgnoreLayerCollision(8, 10);
        }
    }

    /// <summary>
    /// Simple method to check the player's input and react according
    /// </summary>
    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveHorizontal(1.0f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveHorizontal(-1.0f);
        }

        if (GameController.control.player_isSpirit)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MoveVerticle(1.0f);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MoveVerticle(-1.0f);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                MoveVerticle(0.0f);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SwapForms();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveHorizontal(0.0f);
        }
    }
}
