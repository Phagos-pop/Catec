using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Catec _catec;

    private void Start()
    {
        _inputManager.OnClick += Catec_Click; 
    }

    private void Catec_Click()
    {
        _catec.NextSprite();
    }
}
