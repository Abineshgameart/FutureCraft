
using UnityEngine;

public class MotorFuctions : MonoBehaviour
{
    public Assembling assemblingScript;
    public GameObject armBaseRotator;
    public GameObject armBaseMotor;
    public GameObject armHandRotator;


    private bool armBaseRotatorCheck = false;
    private bool armBaseMotorCheck = false;
    private bool armHandRotatorCheck = false;

    private float rotateVal = 20f;


    private void Update()
    {
        if (armBaseRotatorCheck == true && armBaseMotorCheck == true && armHandRotatorCheck == true)
        {
            assemblingScript.MotorCheckTxt.gameObject.SetActive(true);
        }
    }

    public void ArmBaseRotator()
    {   
        if (armBaseRotator != null && assemblingScript.partsAssembled == true)
        {
            Vector3 armBaseCurrentRotation = armBaseRotator.transform.eulerAngles;
            float newZ = Mathf.Clamp(armBaseCurrentRotation.z + rotateVal, -45f, 45f);
            armBaseRotator.transform.rotation = Quaternion.Euler(armBaseCurrentRotation.x, armBaseCurrentRotation.y, newZ);
            armBaseRotatorCheck = true;
            Debug.Log(armBaseRotatorCheck);
        }
    }

    public void ArmBaseMotor()
    {
        if (armBaseMotor != null && assemblingScript.partsAssembled == true)
        {
            Vector3 currentLocalRotation = armBaseMotor.transform.localEulerAngles;
            float newX = Mathf.Clamp(currentLocalRotation.x + rotateVal, -125f, -25f);

            float smoothX = Mathf.LerpAngle(currentLocalRotation.x, newX, Time.deltaTime * 5f); // Adjust 5f for speed


            if (currentLocalRotation.x >= -125f || currentLocalRotation.x <= -25f)
            {
                armBaseMotor.transform.localRotation = Quaternion.Euler(smoothX, currentLocalRotation.y, currentLocalRotation.z);
                armBaseMotorCheck = true;
            }
            Debug.Log(armBaseMotorCheck);
        }
    }

    public void ArmHandRotator()
    {
        if (armHandRotator != null && assemblingScript.partsAssembled == true)
        {
            Vector3 handCurrentLocalRotation = armHandRotator.transform.localEulerAngles;
            float newX = Mathf.Clamp(handCurrentLocalRotation.x + 20f, -90f, 90f);
            float smoothX = Mathf.LerpAngle(handCurrentLocalRotation.x, newX, Time.deltaTime * 5f);
            armHandRotator.transform.localRotation = Quaternion.Euler(smoothX, handCurrentLocalRotation.y, handCurrentLocalRotation.z);
            armHandRotatorCheck = true;
        }
        Debug.Log(armHandRotatorCheck);
    }



}
