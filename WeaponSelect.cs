using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public List<GameObject> guns = new List<GameObject>();
    public List<GameObject> allGuns = new List<GameObject>();
    public Transform gunsPlacement;
    public List<bool> gunSelected = new List<bool>();

    void Update()
    {
        #region Seleção de Armas
        if (Input.GetButtonDown("1"))
        {
            if (!gunSelected[0])
            {
                guns[0].transform.gameObject.SetActive(true);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
                gunSelected[0] = true;
                gunSelected[1] = false;
                gunSelected[2] = false;
                gunSelected[3] = false;
                gunSelected[4] = false;
                gunSelected[5] = false;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("2"))
        {
            if (!gunSelected[1])
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(true);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
                gunSelected[0] = false;
                gunSelected[1] = true;
                gunSelected[2] = false;
                gunSelected[3] = false;
                gunSelected[4] = false;
                gunSelected[5] = false;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("3"))
        {
            if (!gunSelected[2])
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(true);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
                gunSelected[0] = false;
                gunSelected[1] = false;
                gunSelected[2] = true;
                gunSelected[3] = false;
                gunSelected[4] = false;
                gunSelected[5] = false;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("4"))
        {
            if (!gunSelected[3])
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(true);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
                gunSelected[0] = false;
                gunSelected[1] = false;
                gunSelected[2] = false;
                gunSelected[3] = true;
                gunSelected[4] = false;
                gunSelected[5] = false;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("5"))
        {
            if (!gunSelected[4])
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(true);
                guns[5].transform.gameObject.SetActive(false);
                gunSelected[0] = false;
                gunSelected[1] = false;
                gunSelected[2] = false;
                gunSelected[3] = false;
                gunSelected[4] = true;
                gunSelected[5] = false;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonDown("6"))
        {
            if (!gunSelected[5])
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(true);
                gunSelected[0] = false;
                gunSelected[1] = false;
                gunSelected[2] = false;
                gunSelected[3] = false;
                gunSelected[4] = false;
                gunSelected[5] = true;
            }
            else
            {
                guns[0].transform.gameObject.SetActive(false);
                guns[1].transform.gameObject.SetActive(false);
                guns[2].transform.gameObject.SetActive(false);
                guns[3].transform.gameObject.SetActive(false);
                guns[4].transform.gameObject.SetActive(false);
                guns[5].transform.gameObject.SetActive(false);
            }
        }
        #endregion

    }

    public void getGun(int gun)
    {
        GameObject newGun = Instantiate(allGuns[gun], gunsPlacement);
        guns.Add(newGun);
        newGun.SetActive(false);
    }

}
