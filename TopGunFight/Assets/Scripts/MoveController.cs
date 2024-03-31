using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float flySpeed = 15;
    [SerializeField] private float yawAmount = 260f;
    private float yaw;

    // Update is called once per frame
    void Update()
    {
        //Movimentando o objeto
        transform.position += transform.forward * flySpeed *Time.deltaTime;

        //recebendo os imputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);

        // yaw, pitch, roll
        yaw += horizontalInput * yawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        //Aplicando 
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
    }
}
