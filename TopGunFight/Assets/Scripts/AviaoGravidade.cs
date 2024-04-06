using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoGravidade : MonoBehaviour
{
    // Referência ao Rigidbody do avião
    private Rigidbody aviaoRigidbody;

    // Flag para controlar se a gravidade está ativada
    private bool gravidadeAtivada = false;

    private void Start()
    {
        // Obtém o componente Rigidbody do avião
        aviaoRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o avião colidiu com um objeto cubo
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Ativa a gravidade no avião
            aviaoRigidbody.useGravity = true;
            gravidadeAtivada = true;

            // Exibe uma mensagem no console
            Debug.Log("Gravidade ativada para o avião!");
        }

        // Verifica se o avião colidiu com um objeto cubo
        if (collision.gameObject.CompareTag("Bloco"))
        {
            aviaoRigidbody.useGravity = false;
        }
    }

    private void Update()
    {
        // Se a gravidade estiver ativada, podemos adicionar outras lógicas aqui
        if (gravidadeAtivada)
        {
            // Por exemplo, podemos aplicar forças adicionais ao avião
            // para simular a queda sob a influência da gravidade.
            aviaoRigidbody.AddForce(Vector3.down * 9.8f, ForceMode.Acceleration);
        }
    }
}

