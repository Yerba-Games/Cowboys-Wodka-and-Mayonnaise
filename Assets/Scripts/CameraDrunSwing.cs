using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrunSwing : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera camera;
    private CinemachineBasicMultiChannelPerlin cameraPerlin;
    public float intensity;
    public bool shake = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraPerlin = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {

            cameraPerlin.m_AmplitudeGain = intensity;
        }
    }
}
