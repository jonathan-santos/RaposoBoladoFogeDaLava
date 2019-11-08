using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float velocidade = 10;
    public float alturaPulo = 20;

    public GameObject checarChao;
    public LayerMask layerChao;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    Animator animator;

    bool estaNoChao = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        estaNoChao = Physics2D.OverlapPoint(checarChao.transform.position, layerChao);

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * velocidade);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * velocidade);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && estaNoChao)
            rigidBody.AddForce(Vector2.up * alturaPulo);

        animator.SetBool("running", Input.GetAxis("Horizontal") != 0);
        animator.SetBool("jumping", !estaNoChao);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
