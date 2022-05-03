using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonShowing : MonoBehaviour
{
    private GameObject player;
    private Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerMovement>().isMoving)
                anim.SetBool("playerIsMoving", true);
            else
                anim.SetBool("playerIsMoving", false);
        }
    }
}
