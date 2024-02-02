using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 originalCameraPosition;
    [SerializeField] private cameraShake cameraShakeScript;
    [SerializeField] private float magnitude, duration;

    void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    public void StartCameraShake()
    {
        StartCoroutine(cameraShakeScript.Shake(duration, magnitude, player));
    }
}
