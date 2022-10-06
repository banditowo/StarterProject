using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class CurrentPlayerActive : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    public PlayerControls playerOneControls;
    public PlayerControls playerTwoControls;

    public ProjectileHolder projectile1;
    public ProjectileHolder projectile2;

    public PlayerWeapon weapon1;
    public PlayerWeapon weapon2;

    private bool isActive;

    public static PlayerControls activePlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerOneControls.enabled = true;
        playerTwoControls.enabled = false;
        projectile2.enabled = false;

        activePlayer = playerOneControls;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerSwitch();
        }
    }

    private void PlayerSwitch()
    {
        if (activePlayer != playerOneControls)
        {
            Debug.Log("player 1 activation");
            playerOneControls.enabled = true;
            projectile1.enabled = true;
            weapon1.enabled = true;
            playerTwoControls.enabled = false;
            projectile2.enabled = false;
            weapon2.enabled = false;

            activePlayer = playerOneControls;
        }

        else if (activePlayer != playerTwoControls)
        {
            Debug.Log("player 2 activation");
            playerOneControls.enabled = false;
            projectile1.enabled = false;
            weapon1.enabled = false;
            playerTwoControls.enabled = true;
            projectile2.enabled = true;
            weapon2.enabled = true;
            
            activePlayer = playerTwoControls;
        }

        CameraController.CamController.CameraSwitchPlayer(activePlayer.gameObject);
    }

    private void WeaponActivate()
    {
        weapon1 = playerOne.GetComponent<PlayerWeapon>();
        weapon2 = playerTwo.GetComponent<PlayerWeapon>();
    }
}
