using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Analytics;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager instance;
    [Header("Data Manager")]
    public string saveKey;
    private void Awake()
    {
        instance = this;
    }
    public void SavePlayerAdditionalInfo(string value)
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest
        {
           
            Data = new Dictionary<string, string>
            {
                { saveKey, value }
                // Adicione aqui qualquer outra informação adicional que deseja salvar
            },
            Permission = UserDataPermission.Public // Defina a permissão como Pública
        };
        PlayFabClientAPI.UpdateUserData(request, OnSavePlayerDataSuccess, OnSavePlayerDataFailure);
    }

    private void OnSavePlayerDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player additional info saved successfully!");
    }

    private void OnSavePlayerDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to save player additional info: " + error.ErrorMessage);
    }
    public void GetPlayerData()
    {
        var request = new GetUserDataRequest();

        PlayFabClientAPI.GetUserData(request, OnGetUserDataSuccess, OnGetUserDataFailure);
    }

    private void OnGetUserDataSuccess(GetUserDataResult result)
    {
        Debug.Log("Dados do jogador recuperados com sucesso!");
    }

    private void OnGetUserDataFailure(PlayFabError error)
    {
        Debug.LogError("Erro ao recuperar dados do jogador: " + error.GenerateErrorReport());
    }
}
