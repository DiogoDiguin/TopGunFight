using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float velocidade = 100f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 10f;

    //PRIVATE VARIABLES
    private float tempo;

    private void Update()
    {
        //Verifica se a tecla M esta precionada
        if(Input.GetKey(KeyCode.M))
        {
            //incrmente o tempo do tiro
            tempo += Time.deltaTime;

            //verifica se o tempo decorrido é maior ou menor que o intervalo do termpo do tiro
            if(tempo >= intervalo)
            {
                //instancia a bala pelo cano da metralhadora
                GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);

                //ajusta a rotação da bala, nem sempre é nescessario usar
                novaBala.transform.Rotate(90,0,0);

                //destroy a bala para ajuste da memoria
                Destroy(novaBala, 5);

                //é uma boa pratica dar um get, pegar o componente de fisica da bala antes de usar
                Rigidbody rb = novaBala.GetComponent<Rigidbody>();

                //aplica uma força de impulso na bala
                rb.AddForce(cano.forward * velocidade * forçaBala, ForceMode.Impulse);

                //zera o intervalo de termpo 
                tempo = 0f;
            }
        }
    }
}
