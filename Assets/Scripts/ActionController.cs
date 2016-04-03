using UnityEngine;
using System.Collections;
using System;

public class ActionController : MonoBehaviour
{
    public GameObject ChargeLightning;
    public GameObject ShootLightning;
    public GameObject CameraLightningEffect;
    private bool isInputEnabled;
    public float x_LeftLimit;
    public float x_RightLimit;

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
        isInputEnabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        CharacterMovementController();
        Lightning();
    }

    private void CharacterMovementController()
    {
        if (isInputEnabled && transform.position.x > -7.18 && transform.position.x < 8.34)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Input.gyro.rotationRateUnbiased.z * 6);
            transform.position += new Vector3(Input.acceleration.x / 2, 0.0f, 0.0f);
        } else if (transform.position.x <= -7.18) {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y,transform.position.z);

        }
        else if (transform.position.x >= 8.34)
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);

        }
    }

    private void Lightning() {
        if (isInputEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isInputEnabled = false;
                GetComponent<Animator>().SetTrigger("SendLightning");
                ShowCharge();
            }
        }
    }


    void ShowCharge() {
        ChargeLightning.SetActive(true);
    }
    void ShowShoot() {
        ChargeLightning.SetActive(false);
        ShootLightning.SetActive(true);
        CameraLightningEffect.SetActive(true);

    }

    void EndOfLightningAction()
    {
        ChargeLightning.SetActive(false);
        ShootLightning.SetActive(false);
        isInputEnabled = true;
        CameraLightningEffect.SetActive(false);

    }


}
