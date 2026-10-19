using UnityEditor.Search;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform StanleyKubrick; // Referência ao objeto que a câmera vai seguir]
    
    public Vector3 deslocamento = new Vector3(0, 5, -10);

    public float velocidade = 5f;

    // Quanto mais baixo o valor, mais rápido a câmera vai seguir o alvo
    private void LateUpdate()

    {
     Vector3 posicaoDesejada = StanleyKubrick.position + deslocamento;
     transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade* Time.deltaTime);
     transform.LookAt(StanleyKubrick); // faz a câmera olhar para o alvo    }
    }


}
