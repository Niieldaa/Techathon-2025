using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class ConnectUIScript : MonoBehaviour
{
    void OnGUI()
    {
        float w = 200f, h = 40f;
        float x = 20f, y = 10f;  // Starting Y position

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            // Host Button
            if (GUI.Button(new Rect(x, y, w, h), "Host"))
                NetworkManager.Singleton.StartHost();

            // Move y down for the next button
            y += h + 10f;  // extra space

            // Client Button
            if (GUI.Button(new Rect(x, y, w, h), "Client"))
                NetworkManager.Singleton.StartClient();
            
            y += h + 10f;  

            // Server Button
            if (GUI.Button(new Rect(x, y, w, h), "Server"))
                NetworkManager.Singleton.StartServer();
        }
    }
}

