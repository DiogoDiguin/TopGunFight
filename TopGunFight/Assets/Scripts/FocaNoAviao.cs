using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FocaNoAviao : MonoBehaviour
{
    [Header("Configurações do avião")]
    [SerializeField] private GameObject GOaviao001;
    [SerializeField] private GameObject GOaviao002;
    [SerializeField] private GameObject GOaviao003;
    private Transform aviaoAtual;
    [SerializeField]public float velocidadeRotacao = 100f; // Velocidade de rotação
    public float velocidadeProjetil = 35f;
    
    [Header("Configurações da torreta")]
    //public float alturaMinimaParaAtirar = 15f; // Altura mínima para atirar
    [SerializeField]public float intervalo = 5f;
    [SerializeField]public float forcaBala = 2f; // Força aplicada à bala
    private float tempo;
    public Transform canoE; // Posição do cano de onde a bala será disparada
    public Transform canoD; // Posição do cano de onde a bala será disparada
    public GameObject balaPrefab; // Prefab da bala a ser disparada    

    [SerializeField]private string message = "Derrubando o inimigo";

    private void Start()
    {
        Invoke("VerificarAviaoAtual", 2.0f);
    }

    public void VerificarAviaoAtual(){
        if (GOaviao001.activeSelf)
        {
            aviaoAtual = GOaviao001.transform;
        }
        else if (GOaviao002.activeSelf)
        {
            aviaoAtual = GOaviao002.transform;
        }
        else if (GOaviao003.activeSelf)
        {
            aviaoAtual = GOaviao003.transform;
        }
        else
        {
            Debug.Log("Nenhum dos objetos está ativo.");
        }
    }

    private void Update()
    {        
        VerificaAlturaDoAviao();
    }

    private void VerificaAlturaDoAviao()
    {
        //TorpedoSegueAviao();

        transform.LookAt(aviaoAtual);
        // Verifica se o avião está acima da altura mínima para atirar
        if (aviaoAtual.position.y > transform.position.y)
        {
            Debug.Log(message);

            tempo += Time.deltaTime;

            if (tempo >= intervalo)
            {
                // Atira no avião
                GameObject novaBalaE = Instantiate(balaPrefab, canoE.position, canoE.rotation);
                GameObject novaBalaD = Instantiate(balaPrefab, canoD.position, canoD.rotation);

                novaBalaE.transform.Rotate(90, 0, 0);
                novaBalaD.transform.Rotate(90, 0, 0);

                Destroy(novaBalaE, 5);
                Destroy(novaBalaD, 5);

                Rigidbody rbE = novaBalaE.GetComponent<Rigidbody>();
                Rigidbody rbD = novaBalaD.GetComponent<Rigidbody>();

                rbE.AddForce(canoE.forward * forcaBala * velocidadeProjetil, ForceMode.Impulse);
                rbD.AddForce(canoD.forward * forcaBala * velocidadeProjetil, ForceMode.Impulse);

                tempo = 0f;
            }
        }
    }
}