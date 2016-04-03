using UnityEngine;
using System.Collections;
using System;

public class ActionController : MonoBehaviour
{

    private bool isInputEnabled;
	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
        isInputEnabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        CharacterMovementController();

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
        if (Input.GetMouseButtonDown(0)){
            //Lightning animasyonunu başlat karakteri durdur.
        }
    }

}
