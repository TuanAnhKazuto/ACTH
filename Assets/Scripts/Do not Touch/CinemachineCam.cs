using Unity.Cinemachine;
using UnityEngine;

public class CinemachineCam : MonoBehaviour
{
    private CinemachineCamera cineCam;

    private void Awake()
    {
        cineCam = GetComponent<CinemachineCamera>();

        if (cineCam.Target.TrackingTarget == null)
        {
            cineCam.Target.TrackingTarget = GameObject.FindWithTag("Player").transform;
        }
    }
}
