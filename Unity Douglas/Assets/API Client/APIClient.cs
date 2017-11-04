using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    [HideInInspector] public Modelo3D[] modelos = null;
    private const string baseUrl = "http://localhost:55982/API";

    void Start()
    {
        StartCoroutine("GetModelosAPISync");
    }

    IEnumerator GetModelosAPISync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Modelos3D");

        yield return request.Send();

        /*if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }*/

        string response = request.downloadHandler.text;
        Debug.Log(response);

        modelos = JSonHelper.getJsonArray<Modelo3D>(response);

        foreach (Modelo3D i in modelos)
        {
            ImprimirItem(i);
        }
    }

    private void ImprimirItem(Modelo3D i)
    {
        Debug.Log("=========== Dados do Objeto ===========");
        Debug.Log("ID: " + i.Modelo3DID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Idade: " + i.Idade);
        Debug.Log("Altura: " + i.Altura);
        Debug.Log("Peso: " + i.Peso);
        Debug.Log("Historia: " + i.Historia);
        Debug.Log("Habilidade: " + i.Habilidades);

    }
}
