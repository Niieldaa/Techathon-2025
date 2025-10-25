using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class networkConnect : MonoBehaviour
{
    public void Create()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}