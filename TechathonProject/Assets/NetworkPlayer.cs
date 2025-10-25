using System;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
  public Transform root;
  public Transform head;
  public Transform leftHand;
  public Transform rightHand;

  public Renderer[] meshToDisable;


  public override void OnNetworkSpawn()
  {
    base.OnNetworkSpawn();
    
    if (IsOwner)
    {
      foreach (var item in meshToDisable)
      {
        item.enabled = false;
      }
    }
  }

  private void Update()
  {
    if (IsOwner)
    {
      root.position = VRRigRefrence.Singleton.root.position;
      root.rotation = VRRigRefrence.Singleton.root.rotation;
    
      head.position = VRRigRefrence.Singleton.root.position;
      head.rotation = VRRigRefrence.Singleton.root.rotation;
    
      leftHand.position = VRRigRefrence.Singleton.root.position;
      leftHand.rotation = VRRigRefrence.Singleton.root.rotation;
    
      rightHand.position = VRRigRefrence.Singleton.root.position;
      rightHand.rotation = VRRigRefrence.Singleton.root.rotation;
    }
  }
}
