using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSControl : MonoBehaviour
{
    public float walkSpeed = 7.5f;
    public float runSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public bool holdJump = false;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove;
    public bool canShoot;

    #region Munição
    public Slider reloadSlider;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI ammoTypeText;
    public int actualAmmo;
    public float reloadTime;
    public float maxReloadTime;
    public GameObject gun;

    //Munições do personagem
    public int rifleAmmo = 10;
    public int pistolAmmo = 10;
    public int heavyAmmo = 10;
    public int shotgunShell = 10;
    #endregion

    public void Start()
    {
        canMove = false;
        characterController = GetComponent<CharacterController>();

        #region Cursor travado
        #endregion
    }

    public void Update()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
        #region Munição na UI
        if (gun != null)
        {
            if (gun.GetComponent<Gun>().rifleAmmo)
            {
                ammoText.text = actualAmmo + "/" + rifleAmmo;
                ammoTypeText.text = "Rifle";
            }
            if (gun.GetComponent<Gun>().pistolAmmo)
            {
                ammoText.text = actualAmmo + "/" + pistolAmmo;
                ammoTypeText.text = "Pistol";

            }
            if (gun.GetComponent<Gun>().heavyAmmo)
            {
                ammoText.text = actualAmmo + "/" + heavyAmmo;
                ammoTypeText.text = "Heavy";

            }
            if (gun.GetComponent<Gun>().shotgunShell)
            {
                ammoText.text = actualAmmo + "/" + shotgunShell;
                ammoTypeText.text = "Shotgun";

            }
        } else
        {
            ammoText.text = "";
            ammoTypeText.text = "";
        }
        #endregion
        reloadSlider.minValue = 0;
        reloadSlider.maxValue = maxReloadTime;
        reloadSlider.value = reloadTime;

        #region Movimentação e Input do usuário
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetButton("Run");
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (!holdJump)
        {
            if (Input.GetButtonDown("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
        } else
        {
            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnlockChar()
    {
        canMove = true;

    }
    public void LockChar()
    {
        canMove = false;

    }
}