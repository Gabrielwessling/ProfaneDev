using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float healthActual = 50;
    public float healthMax = 50;

    // Start is called before the first frame update
    public void TakeDamage(float amount)
    {
        healthActual -= amount;
        if (healthActual <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    public void Die()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }
}
