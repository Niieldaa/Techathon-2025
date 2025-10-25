using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Fusion;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    // Singleton pattern
    public static NetworkManager instance { get; private set; }

    [SerializeField] private GameObject _runnerPrefab;
    
    public NetworkRunner Runner { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        Fusion.Photon.Realtime.PhotonAppSettings.Instance.AppSettings.FixedRegiom = "europe";
    }

    public async void CreateSession(string roomCode)
    {
        InitializeRunner();
        await LoadScene();
        await ConnectionManager(roomCode);
    }

    public async void JoinSession(string roomCode)
    {
        InitializeRunner();
        await LoadScene();
        await ConnectionManager(roomCode);
    }

    public void InitializeRunner()
    {
        if (Runner == null)
        {
            Runner = Instantiate(_runnerPrefab).GetComponent<NetworkRunner>();
            Runner.AddCallbacks(this);
        }
        Runner.ProvideInput = true; // Ensure networked input
    }

    public async Task LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        
        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }
    }

    private async Task Connect(string sessionName)
    {
        var args = new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = sessionName,
            SceneManager = GetComponent<NetworkSceneManagerDefault>(),
            Scene = 1
        };
        await Runner.StartGame(args);
    }

    private async Task ConnectionManager(string roomCode)
    {
        if (string.IsNullOrEmpty(roomCode))
        {
            Debug.LogError("Room code is empty.");
            return;
        }

        // Simulated creation/join logic
        if (roomCode.StartsWith("create"))
        {
            await CreateSession(roomCode);
        }
        else
        {
            await JoinSession(roomCode);
        }
    }

    // Implement INetworkRunnerCallbacks
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Player {player} joined.");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Player {player} left.");
    }

    public void OnGameStarted(NetworkRunner runner)
    {
        Debug.Log("Game started.");
    }

    public void OnGameFinished(NetworkRunner runner)
    {
        Debug.Log("Game finished.");
    }

    public void Disconnect()
    {
        if (Runner != null)
        {
            Runner.Shutdown();
            Runner = null;
            Debug.Log("Disconnected from session.");
        }
    }
}
