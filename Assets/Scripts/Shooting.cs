using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerController player;
    private Camera mainCam;
    private Vector3 mousePos;
    public AudioSource audioSource;

    private GameObject chosenArrow;
    public GameObject regArrow;
    public GameObject expArrow;
    public GameObject poiArrow;
    public GameObject froArrow;

    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    float delay;

    public cameraShake camShake;
    private CameraController camController;

    Upgrades upg;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
        camController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        upg = GetComponentInParent<Upgrades>();
        chosenArrow = regArrow;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(upg.expArrow)
        {
            chosenArrow = expArrow;
        }
        else
        {
            if(upg.poiArrow)
            {
                chosenArrow = poiArrow;
            }
            else
            {
                if (upg.froArrow)
                {
                    chosenArrow = froArrow;
                }
                else
                    chosenArrow = regArrow;
            }
        }

        if(!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        if(Input.GetMouseButton(0) && canFire && !player.invRolling)
        {
            canFire = false;
            if (upg.multiShot)
            {
                StartCoroutine(DoubleFire());
            }
            else
            {
                Instantiate(chosenArrow, bulletTransform.position, Quaternion.identity);
                audioSource.Play();
                //camController.StartCameraShake();
            }
        }

    }

    IEnumerator DoubleFire()
    {
        Instantiate(chosenArrow, bulletTransform.position, Quaternion.identity);
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        Instantiate(chosenArrow, bulletTransform.position, Quaternion.identity);
        audioSource.Play();
    }
}
