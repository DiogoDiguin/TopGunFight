using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MenuEscolha;
    [SerializeField] private GameObject[] listaAviao;
    public FocaNoAviao focaNoAviaoScript;

    public void BtnInstanciaAviao(int x)
    {

        listaAviao[x].SetActive(true);

        MenuEscolha.SetActive(false);
        focaNoAviaoScript.VerificarAviaoAtual();
    }
}