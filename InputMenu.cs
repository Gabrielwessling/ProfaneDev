using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenu : MonoBehaviour
{
    public GameObject gmobj;
    public GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gmobj.SetActive(true);
            gameObject.SetActive(false);
            player.GetComponent<FPSControl>().UnlockCursor();
            player.GetComponent<FPSControl>().LockChar();
        }
    }
}
