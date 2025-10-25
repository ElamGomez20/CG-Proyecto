using UnityEngine;

public class CamaraPortal : MonoBehaviour
{
    public Transform playerCamera;  
    public Transform portal;         
    public Transform linkedPortal;   

    void LateUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - linkedPortal.position;
        Quaternion portalRotationDifference = Quaternion.AngleAxis(180f, Vector3.up) *
        (portal.rotation * Quaternion.Inverse(linkedPortal.rotation));
        transform.rotation = portalRotationDifference * playerCamera.rotation;
    }
}
