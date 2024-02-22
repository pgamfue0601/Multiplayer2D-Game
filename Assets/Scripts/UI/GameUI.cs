using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : NetworkBehaviour
{
    [SerializeField] Button exit;

    private void Start()
    {
        exit.onClick.AddListener(() => ExitGameActual());
    }

    void ExitGameActual()
    {
        if (exit.CompareTag("Single"))
        {
            SceneManager.LoadScene("MenuScene");
        } else
        {
            if (IsOwnedByServer)
            {
                foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
                {
                    MultiplayerManager.Instance.KickPlayer(clientId);
                }
            }
            SceneManager.LoadScene("MenuScene");
        }
    }
}
