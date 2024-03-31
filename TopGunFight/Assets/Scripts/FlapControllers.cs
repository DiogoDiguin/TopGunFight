using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapControllers : MonoBehaviour
{
    public float speed = 90f; // Velociade de rotação em Graus por sgundo
    public float minAngle = -35f; // Ângulo mínimo
    public float maxAngle = 35f; // Ângulo máximo
    private float currentAngle = 0f; // Ângulo atual
    [SerializeField] private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        //Obtem os inputs do teclado
        float input = Input.GetAxis("Horizontal");

        //Calculo do ângulo de rotação, baseado no input e velocidade
        float angle = input * speed * Time.deltaTime;

        // Calcula o novo ângulo aplicando a rotação
        currentAngle += angle;

        // Limitando o ângulo de rotação.
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        //Aplicando a rotação ao objeto.
        transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
        
    }
}
