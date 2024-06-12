using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabTitleData : MonoBehaviour
{
    [Header("Title Data Key")]
    public string titleDataKey = "Wallet";
    public string value;
    public void LoadTitleData()
    {
        // Configura��o da solicita��o para obter os dados do t�tulo
        var request = new GetTitleDataRequest();

        // Chama a API PlayFab para obter os dados do t�tulo
        PlayFabClientAPI.GetTitleData(request, OnTitleDataReceived, OnTitleDataError);
    }
    void OnTitleDataReceived(GetTitleDataResult result)
    {
        // Verifica se a chave desejada est� presente nos dados do t�tulo
        if (result.Data.ContainsKey(titleDataKey))
        {
            // Recupera o valor associado � chave desejada
            value = result.Data[titleDataKey];
            PlayerPrefs.SetString("Wallet", value);
            PlayerPrefs.Save();
            Debug.Log("Valor da chave '" + "WalletPlayfab" + "': " + value);
        }
        else
        {
            Debug.LogWarning("Chave '" + titleDataKey + "' n�o encontrada nos dados do t�tulo.");
        }
    }
    void OnTitleDataError(PlayFabError error)
    {
        Debug.LogError("Erro ao carregar dados do t�tulo: " + error.ErrorMessage);
    }
}
