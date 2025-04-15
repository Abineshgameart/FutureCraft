using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Assembling : MonoBehaviour
{
    // Public 
    public List<GameObject> list1;
    public List<GameObject> list2;
    public TextMeshProUGUI successTxt;
    public TextMeshProUGUI failTxt;
    public TextMeshProUGUI MotorCheckTxt;
    public GameObject roboticArmTrans;
    public GameObject roboticArmParts;
    public GameObject roboticArmPartsAssembled;

    // Private
    public bool partsAssembled = false;

    private void Start()
    {
        roboticArmPartsAssembled.SetActive(false);
        failTxt.gameObject.SetActive(false);
        successTxt.gameObject.SetActive(false);
        MotorCheckTxt.gameObject.SetActive(false);
    }

    public void AssemblyCheck()
    {
        Debug.Log("Assembled");
        int assembledPartsCount = 0;

        if (list1.Count > 0 && list2.Count > 0)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].transform.position == list2[i].transform.position)
                {
                    assembledPartsCount++;
                }
            }
        }

        Debug.Log(assembledPartsCount);
        Debug.Log(list2.Count);

        if (assembledPartsCount == list1.Count)
        {
            partsAssembled = true;
            failTxt.gameObject.SetActive(false);

            foreach (GameObject part in list2)
            {
                CollisionHandler partScript = part.GetComponent<CollisionHandler>();
                part.transform.SetParent(partScript.ParentObject);
            }

            successTxt.gameObject.SetActive(true);
            Debug.Log("True");
            roboticArmParts.SetActive(false);
            roboticArmTrans.SetActive(false);
            roboticArmPartsAssembled.SetActive(true);

        } else
        {
            partsAssembled = false;
            successTxt.gameObject.SetActive(false);
            failTxt.gameObject.SetActive(true);
            Debug.Log("false");
        }
    }
}
