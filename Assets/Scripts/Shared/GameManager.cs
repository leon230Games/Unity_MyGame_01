using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager {

    #region Singleton
    private GameObject gameObject;

    //TODO rework singletonPattern
    private static GameManager mInstance;
    public static GameManager instance
    {
        get
        {
            if(mInstance == null)
            {
                Debug.Log("Assigning GameManager");
                mInstance = new GameManager();
                mInstance.gameObject = new GameObject(gameConstants.gameManager);
                mInstance.gameObject.AddComponent<InputController>();
                mInstance.gameObject.AddComponent<Timer>();
            }
            else
            {
                //Debug.Log("GameManager already defined");
            }
            
            return mInstance;
        }

    }
    #endregion

    public event System.Action<Player> OnLocalPlayerJoined;

    private InputController mInputController;
    public InputController inputController
    {
        get
        {
            if (mInputController == null)
            {
                mInputController = gameObject.GetComponent<InputController>();
            }
            return mInputController;
        }
    }

    private Player mLocalPlayer;
    public Player localPlayer
    {
        get
        { return mLocalPlayer; }

        set
        {
            mLocalPlayer = value;
            if (OnLocalPlayerJoined != null)
            {
                OnLocalPlayerJoined(mLocalPlayer);
            }
        }
    }

    private Timer mTimer;
    public Timer timer
    {
        get
        {
            if (mTimer == null)
            {
                mTimer = gameObject.GetComponent<Timer>();
            }
            return mTimer;
        }

    }

    public void DisableMovementAndCamera()
    {
        GameObject.Find(gameConstants.mainCamera).GetComponent<CameraController>().enabled = false;
        GameObject.Find(gameConstants.player).GetComponent<RelativeMovement>().enabled = false;
        GameObject.Find(gameConstants.player).GetComponent<PlayerAnimation>().enabled = false;

        Animator animator = GameObject.Find(gameConstants.playerGfx).GetComponent<Animator>();
        animator.SetBool(gameConstants.isCrouching, false);
        animator.SetBool(gameConstants.isSprinting, false);
        animator.SetBool(gameConstants.isWalking, false);
        animator.SetFloat(gameConstants.horizontal, 0f);
        animator.SetFloat(gameConstants.vertical, 0f);
    }

    public void EnableMovementAndCamera()
    {
        GameObject.Find(gameConstants.mainCamera).GetComponent<CameraController>().enabled = true;
        GameObject.Find(gameConstants.player).GetComponent<RelativeMovement>().enabled = true;
        GameObject.Find(gameConstants.player).GetComponent<PlayerAnimation>().enabled = true;
    }

    public void MouseCursorEnabled(bool enabled)
    {
        Cursor.visible = enabled;
        if(enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

}
