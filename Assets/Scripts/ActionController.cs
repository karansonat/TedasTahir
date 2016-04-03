using UnityEngine;
using System.Collections;
using System;

public class ActionController : MonoBehaviour
{
    public GameObject ChargeLightning;
    public GameObject ShootLightning;
    private bool isInputEnabled;


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
        if (isInputEnabled)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Input.gyro.rotationRateUnbiased.z * 6);
            transform.position += new Vector3(Input.acceleration.x / 2, 0.0f, 0.0f);
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
    }

    void EndOfLightningAction()
    {
        ChargeLightning.SetActive(false);
        ShootLightning.SetActive(false);
        isInputEnabled = true;

    }


}
