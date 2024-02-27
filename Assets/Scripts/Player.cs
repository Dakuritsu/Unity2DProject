using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour
{   
    private PlayerController playerController;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
}
