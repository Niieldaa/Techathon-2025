using UnityEngine;

public class VRRigRefrence : MonoBehaviour
{
    
    public static VRRigRefrence Singleton;
    
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private void Awake()
    {
        Singleton = this;
    }
}
