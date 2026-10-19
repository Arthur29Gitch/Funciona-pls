using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MovimentoPlayer : MonoBehaviour
{

    [Header("Movimento")]

    public float velocidade = 5f;


    public float velocidadeGiro = 720f;


    [Header("Pulo Gravidade")]

    public float alturaPulo = 5f;

    public float gravidade = -20f;


    private CharacterController Controller;


    private float velocidadeY;


    void Start()

    {

        Controller = GetComponent<CharacterController>();

    }

    void Update()

    {

        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(h, 0, v);

        if (direcao.magnitude > 1f)

        {

            direcao.Normalize();

        }



        if (direcao != Vector3.zero)

        {

            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoAlvo, velocidadeGiro * Time.deltaTime);

        }

        if (Controller.isGrounded)

        {

            if (velocidadeY < 0)

            {

                velocidade = 12f;

            }

            if (Input.GetKeyDown(KeyCode.Space))

            {

                velocidadeY = Mathf.Sqrt(alturaPulo * -2f * gravidade);

            }

        }

        velocidadeY += gravidade * Time.deltaTime;

        Vector3 movimento = direcao * velocidade;

        movimento.y = velocidadeY;

        Controller.Move(movimento * Time.deltaTime);

    }

}