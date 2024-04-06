using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsToPlane : MonoBehaviour
{
    [SerializeField] private TMP_Text qtdPontos;
    private int pontuacao = 0;
    private bool tempoParado = false;
    private bool colisaoComBala = false;
    private float tempoInicial = 0f; // Variável para armazenar o tempo inicial da partida

    // Prefab de BalaAviao
    public GameObject balaAviaoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Reiniciar a partida ao iniciar o jogo
        ReiniciarPartida();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tempoParado)
        {
            // Obter o tempo decorrido desde o início do jogo
            float tempoDecorrido = Time.time - tempoInicial;

            // Converter o tempo decorrido em segundos
            int segundos = Mathf.FloorToInt(tempoDecorrido);

            // Atualizar o componente TMP_Text com os segundos
            qtdPontos.text = pontuacao.ToString() + " - " + segundos.ToString();
        }
    }

    // Método para atualizar o texto da pontuação
    void AtualizarPontuacao()
    {
        if (!colisaoComBala)
        {
            qtdPontos.text = pontuacao.ToString();
        }
    }

    // Método para adicionar pontos à pontuação
    public void AdicionarPontos(int pontos)
    {
        if (!colisaoComBala)
        {
            pontuacao += pontos;
            AtualizarPontuacao();
        }
    }

    // Método chamado quando ocorre uma colisão
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido é uma caixa
        if (collision.gameObject.CompareTag("Bloco"))
        {
            // Verifica se a colisão envolve um prefab de "BalaAviao"
            if (balaAviaoPrefab != null && !colisaoComBala)
            {
                // Adiciona 10 pontos à pontuação
                AdicionarPontos(10);
            }
        }

        // Verifica se o avião colidiu com um objeto de tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Define a variável tempoParado como true para parar de atualizar a pontuação com o tempo
            tempoParado = true;
            colisaoComBala = true;

            // Zera os segundos para uma nova partida
            Invoke("ReiniciarPartida", 2.0f);
            //ReiniciarPartida();
        }
    }

    // Método para reiniciar a partida
    void ReiniciarPartida()
    {
        pontuacao = 0;
        tempoParado = false;
        colisaoComBala = false;
        tempoInicial = Time.time; // Define o tempo inicial da partida
        AtualizarPontuacao();
    }
}
