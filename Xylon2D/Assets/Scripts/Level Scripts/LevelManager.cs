using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    private CharacterController2D control;

    public CinemachineVirtualCameraBase cam;




    private void Awake()
    {

        instance = this;

    }

    public void GameOver()
    {
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null)
        {   
            _ui.ToggleDeathPanel();
 
        }
    }

  

}
