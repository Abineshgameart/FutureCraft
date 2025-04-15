using UnityEngine;

public class AssembledMotorFunctions : MonoBehaviour
{
    public GameObject assembledArmBaseRotator;
    public GameObject assembledArmBaseMotor;
    public GameObject assembledArmHandRotator;

    private float rotateVal = 5f;

    public void AssembledArmBaseRotator()
    {
        if (assembledArmBaseRotator != null)
        {
            Vector3 assembledArmBaseCurrentRotation = assembledArmBaseRotator.transform.eulerAngles;
            float newZ = Mathf.Clamp(assembledArmBaseCurrentRotation.z + rotateVal, -45f, 45f);
            assembledArmBaseRotator.transform.rotation = Quaternion.Euler(assembledArmBaseCurrentRotation.x, assembledArmBaseCurrentRotation.y, newZ);
        }
    }

    public void AssembledArmBaseMotor()
    {
        if (assembledArmBaseMotor != null)
        {
            Vector3 currentLocalRotation = assembledArmBaseMotor.transform.localEulerAngles;
            float newX = Mathf.Clamp(currentLocalRotation.x + rotateVal, -125f, -25f); 

            float smoothX = Mathf.LerpAngle(currentLocalRotation.x, newX, Time.deltaTime * 5f); // Adjust 5f for speed


            if (currentLocalRotation.x >= -125f || currentLocalRotation.x <= -25f)
            {
                assembledArmBaseMotor.transform.localRotation = Quaternion.Euler(smoothX, currentLocalRotation.y, currentLocalRotation.z);
            }
        }
    }

    public void AssembledArmHandRotator()
    {
        if (assembledArmHandRotator != null)
        {
            Vector3 handCurrentLocalRotation = assembledArmHandRotator.transform.localEulerAngles;
            float newX = Mathf.Clamp(handCurrentLocalRotation.x + 20f, -90f, 90f);
            float smoothX = Mathf.LerpAngle(handCurrentLocalRotation.x, newX, Time.deltaTime * 5f);
            assembledArmHandRotator.transform.localRotation = Quaternion.Euler(smoothX, handCurrentLocalRotation.y, handCurrentLocalRotation.z);
        }
       
    }
}
