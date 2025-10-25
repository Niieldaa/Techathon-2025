using UnityEngine;
using Fusion;
using System.Threading.Tasks;

public class ConnectionManager : MonoBehaviour
{
    public NetworkRunner runner;

    // Initializes a connection, either creating or joining a session.
    public async void InitializeConnection(bool isHost, string sessionName = "DefaultSession")
    {
        if (isHost)
        {
            await CreateHost(sessionName);
        }
        else
        {
            await JoinSession(sessionName);
        }
    }

    private async Task CreateHost(string sessionName)
    {
        var args = new StartGameArgs()
        {
            GameMode = GameMode.Host,
            SessionName = sessionName,
            SceneManager = GetComponent<NetworkSceneManagerDefault>(),
            Scene = 1  // Scene index to load
        };

        await runner.StartGame(args);
    }

    private async Task JoinSession(string sessionName)
    {
        var args = new JoinGameArgs()
        {
            SessionName = sessionName,
            SceneManager = GetComponent<NetworkSceneManagerDefault>(),
            Scene = 1  // Scene index to load
        };

        await runner.JoinGame(args);
    }

    public void Disconnect()
    {
        if (runner != null)
        {
            runner.Shutdown();
            Debug.Log("Disconnected from session.");
        }
    }
}