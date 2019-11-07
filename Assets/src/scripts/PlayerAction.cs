using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float velocidade = 10;
    public float alturaPulo = 20;

    public GameObject checarChao;
    public LayerMask layerChao;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    bool estaNoChao = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        Debug.Log("estaNoChao: " + estaNoChao);

        if (Input.GetAxis("Vertical") > 0 && estaNoChao)
            rigidBody.AddForce(Vector2.up * alturaPulo);
    }
}
