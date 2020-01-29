using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToPick : MonoBehaviour
{
    public int gunNumber = 1;
    public float rotationSpeed = 1f;
    public GameObject theGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotationSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<WeaponSelect>().guns.Count < 5)
            {
                other.GetComponent<WeaponSelect>().getGun(gunNumber);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("You little bitch, you don't have fucking space, bitch");
            }
        }
    }
}
