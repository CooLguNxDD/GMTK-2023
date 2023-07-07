using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

using System;

public class MouseController : MonoBehaviour
{
    public static MouseController Instance { get; set; } //need to be private

    //subscribe to these two event for mouse controller
    public event EventHandler MouseOnRightClickEvent;
    public event EventHandler MouseOnLeftClickEvent;

    //mouse position to world coordinate
    public Vector3 mousePosition;

    // Cool down timer between clicks
    private float ClickingCoolDown;
    public float ClickingCoolDownSetting;
    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("only one MouseController instance available");
        }
        Instance = this;
        ClickingCoolDown = ClickingCoolDownSetting;
    }
    // Update is called once per frame
    void Update()
    {
        ClickingCoolDown -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Debug.Log("working");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }
}
