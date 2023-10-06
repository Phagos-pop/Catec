using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public event Action OnClick;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnClick.Invoke();
        }
    }
}
