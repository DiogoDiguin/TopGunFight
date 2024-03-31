using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update

    /*[SerializeField] private Transform aviao001;
    [SerializeField] private Transform aviao002;
    [SerializeField] private Transform aviao003;*/
    /*[SerializeField] private Transform aviaoPrefab001;
    [SerializeField] private Transform aviaoPrefab002;
    [SerializeField] private Transform aviaoPrefab003;*/
    [SerializeField] private GameObject MenuEscolha;
    [SerializeField] private GameObject[] listaAviao;
    public FocaNoAviao focaNoAviaoScript;

    /*public void BtnAdicionarAviao(){
        Debug.Log("Botão clicado. Tag do objeto: " + gameObject.tag);

        if (gameObject.tag == "Btn001")
        {
            Debug.Log("Instanciando avião 001");
            Instantiate(aviaoPrefab001);
        }
        else if (gameObject.tag == "Btn002")
        {
            Debug.Log("Instanciando avião 002");
            Instantiate(aviaoPrefab002);
        }
        else if (gameObject.tag == "Btn003")
        {
            Debug.Log("Instanciando avião 003");
            Instantiate(aviaoPrefab003);
        }
        else
        {
            Debug.LogWarning("Tag do botão não reconhecida: " + gameObject.tag);
        }

        MenuEscolha.SetActive(false);
    }*/

    public void BtnInstanciaAviao(int x)
    {
        // Instancia o avião
        //GameObject aviaoInstanciado = Instantiate(listaAviao[x]);
        
        //listaAviao[x].SetActive(true);

        // Define o avião instanciado como ativo
        listaAviao[x].SetActive(true);

        // Atribui o GameObject do avião instanciado à variável aviao do script FocaNoAviao
        /*if(focaNoAviaoScript != null) // Verifica se a referência ao FocaNoAviao foi estabelecida
        {
            focaNoAviaoScript.aviaoAtual = aviaoInstanciado.transform;
        }
        else
        {
            Debug.LogError("FocaNoAviaoScript não está atribuído ao MenuController.");
        }*/

        MenuEscolha.SetActive(false);
        focaNoAviaoScript.VerificarAviaoAtual();
    }
}