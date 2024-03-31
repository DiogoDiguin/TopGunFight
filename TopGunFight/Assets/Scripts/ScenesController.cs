using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    public void BtnNextGameScene(){
        SceneManager.LoadScene("Login");
    }

    public void BtnNextCreditos(){
        SceneManager.LoadScene("Creditos");
    }

    public void BtnSampleScene(){
        SceneManager.LoadScene("SampleScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
