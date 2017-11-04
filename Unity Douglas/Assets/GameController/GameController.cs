using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text Texto;
    private APIClient APICliente;
	// Use this for initialization
	void Start () {
        APICliente = gameObject.GetComponent<APIClient>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        Texto.text = " Nome: " + APICliente.modelos[0].Nome + "\n Idade: " + APICliente.modelos[0].Idade + "\n Altura: " + APICliente.modelos[0].Altura + "\n Peso: " + APICliente.modelos[0].Peso +
            "\n História: " + APICliente.modelos[0].Historia + "\n Habilidades: " + APICliente.modelos[0].Habilidades;
    }
}
