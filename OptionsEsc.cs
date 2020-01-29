using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsEsc : MonoBehaviour
{

    public GameObject UIToSetActive;
    public GameObject UIToSetActive1;
    public GameObject UIToSetActive2;
    public GameObject UIToSetNoActive;
    public GameObject UIToSetNoActive1;
    public GameObject UIToSetNoActive2;

    public bool freeCam;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (UIToSetActive != null)
            UIToSetActive.SetActive(true);

            if (UIToSetNoActive != null)
                UIToSetNoActive.SetActive(false);

            if (UIToSetActive1 != null)
                UIToSetActive1.SetActive(true);

            if (UIToSetNoActive1 != null)
                UIToSetNoActive1.SetActive(false);

            if (UIToSetActive2 != null)
                UIToSetActive2.SetActive(true);

            if (UIToSetNoActive2 != null)
                UIToSetNoActive2.SetActive(false);

            if (freeCam)
            {
                player.GetComponent<FPSControl>().UnlockChar();
                player.GetComponent<FPSControl>().LockCursor();
            }
        }
    }
}
