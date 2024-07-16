using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;
    public static InputHandler instance;

    #endregion


    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        instance = this;
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }

        GameObject obj = rayHit.collider.gameObject;

        if (rayHit.collider.gameObject != null) 
        {
            //Debug.Log("ClickOnCard");
            if (rayHit.collider.gameObject.GetComponent<Card>() != null)
            {
                GameManager.instance.SelectCard(obj);
            }

        }


       
        //Debug.Log(rayHit.collider.gameObject.name);
    }
}
