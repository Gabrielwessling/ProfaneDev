using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoToPick : MonoBehaviour
{
    public int rifleAmmo;
    public int pistolAmmo;
    public int heavyAmmo;
    public int shotgunShell;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<FPSControl>().rifleAmmo += rifleAmmo;
            other.GetComponent<FPSControl>().pistolAmmo += pistolAmmo;
            other.GetComponent<FPSControl>().heavyAmmo += heavyAmmo;
            other.GetComponent<FPSControl>().shotgunShell += shotgunShell;
            Debug.Log("You obtained " + rifleAmmo + " rifle ammo, " + pistolAmmo + " pistol ammo, " + heavyAmmo + " heavy ammo, and " + shotgunShell + " shells");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
