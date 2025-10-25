using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameLogic : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
  [SerializeField] private NetworkPrefabRef playerPrefab;
  [Networked, Capacity(2)] private NetworkDictionary<PlayerRef, Player> Players => default;
  public void PlayerJoined(PlayerRef player)
  {
    if(HasStateAuthority)
      {
        NetworkObject playerObject = Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity, player);
        Players.Add(player, playerObject.GetComponent<Player>());
        Debug.Log("Player joined");
      }
  }
  
  public void PlayerLeft(PlayerRef player)
  {
    if(!HasStateAuthority)
      return;

    Player playerBehavior;
    if (Players.TryGet(player, out playerBehavior))
    {
      Players.Remove(player);
      Runner.Despawn(playerBehavior.Object);
    }
  }

}
