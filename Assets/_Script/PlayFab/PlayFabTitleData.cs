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
        // Configuração da solicitação para obter os dados do título
        var request = new GetTitleDataRequest();

        // Chama a API PlayFab para obter os dados do título
        PlayFabClientAPI.GetTitleData(request, OnTitleDataReceived, OnTitleDataError);
    }
    void OnTitleDataReceived(GetTitleDataResult result)
    {
        // Verifica se a chave desejada está presente nos dados do título
        if (result.Data.ContainsKey(titleDataKey))
        {
            // Recupera o valor associado à chave desejada
            value = result.Data[titleDataKey];
            PlayerPrefs.SetString("Wallet", value);
            PlayerPrefs.Save();
            Debug.Log("Valor da chave '" + "WalletPlayfab" + "': " + value);
        }
        else
        {
            Debug.LogWarning("Chave '" + titleDataKey + "' não encontrada nos dados do título.");
        }
    }
    void OnTitleDataError(PlayFabError error)
    {
        Debug.LogError("Erro ao carregar dados do título: " + error.ErrorMessage);
    }
}
