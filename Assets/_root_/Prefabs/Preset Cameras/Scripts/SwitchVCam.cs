using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Canvas tppCanvas;
    [SerializeField]
    private Canvas aimCanvas;
    [SerializeField]
    private Image aimReticle;

    private int priorityBoostAmount =10;
    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;


    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aiming"];
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }
    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }
    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
        //aimCanvas.enabled = true;
        tppCanvas.enabled = false;
        aimReticle.enabled = true;
        
    }
    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        //aimCanvas.enabled = false;
        tppCanvas.enabled = true;
        aimReticle.enabled = false;
    }

}
