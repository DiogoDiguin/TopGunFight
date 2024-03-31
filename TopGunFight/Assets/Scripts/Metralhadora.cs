using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralhadora : MonoBehaviour 
{
    public float velocidade = 100f;
    public Transform cano;
    public GameObject bala;
    public float intervalo;
    public float forcaBala = 2f;

    private float tempo = 5f;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Atirou");
            tempo += Time.deltaTime;

            if (tempo >= intervalo)
            {
                GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);
                
                novaBala.transform.Rotate(90,0,0);

                Rigidbody rb = novaBala.GetComponent<Rigidbody>();
                
                rb.AddForce(cano.forward * velocidade * forcaBala, ForceMode.Impulse);

                tempo = 0f;
                
                Destroy(novaBala, 5);
                
            }

        }
    }
}
