using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool checkWalk;
    private float speedHorizontal, timeJump;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        if (checkWalk == true)
        {
            timeJump -= Time.deltaTime;

            if (timeJump <= 0)
            {
                checkWalk = false;
                this.gameObject.GetComponent<Animator>().SetBool("ToFall", false);
            }
        }
    }

    //Assigns the player move and anomation
    public void MovePlayer()
    {
        speedHorizontal = Input.GetAxisRaw("Horizontal");

        if (speedHorizontal > 0 && checkWalk == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            this.gameObject.GetComponent<Animator>().SetFloat("SpeedHorizontal", speedHorizontal);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.GetComponent<Animator>().SetBool("Idle", false);
        }
        else if (speedHorizontal < 0 && checkWalk == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            this.gameObject.GetComponent<Animator>().SetFloat("SpeedHorizontal", -speedHorizontal);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<Animator>().SetBool("Idle", false);
        }
        else
            this.gameObject.GetComponent<Animator>().SetBool("Idle", true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tagEspinho"))
            SceneManager.LoadScene("Home");

        if (collision.gameObject.CompareTag("FinalFase"))     
            SceneManager.LoadScene("Home");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tagGround"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Jump", false);
            this.gameObject.GetComponent<Animator>().SetBool("ToFall", true);
            checkWalk = true;
            timeJump = 0.5f;
        }
        else
            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tagGround"))
            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
    }
}
