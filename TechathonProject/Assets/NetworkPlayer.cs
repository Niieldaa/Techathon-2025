using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public static VrRigReferences Singleton;
    
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    void Update()
    {
        if (IsOwner)
        {
            root.position = VrRigReferences.Singleton.root.position;
            root.rotation = VrRigReferences.Singleton.root.rotation;
        
            head.position = VrRigReferences.Singleton.root.position;
            head.rotation = VrRigReferences.Singleton.root.rotation;
        
            leftHand.position = VrRigReferences.Singleton.root.position;
            leftHand.rotation = VrRigReferences.Singleton.root.rotation;
        
            rightHand.position = VrRigReferences.Singleton.root.position;
            rightHand.rotation = VrRigReferences.Singleton.root.rotation;
        }
    }
}
