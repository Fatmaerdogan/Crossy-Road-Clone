using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isJump;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJump)
        {
            float zDifference = 0;
            if(transform.position.z%1!=0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            Move(new Vector3(zDifference, 0,1));
        }
        else if(Input.GetKeyDown(KeyCode.A)&& !isJump)
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isJump)
        {
            Move(Vector3.right);
        }
    }
    public void Move(Vector3 MoveDirestion)
    {
        animator.SetTrigger("Jump");
        FinishJump();
        transform.position = transform.position +MoveDirestion;
        Events.SpawnTerrain?.Invoke(transform.position);
        Events.ScoreChange?.Invoke(10);
    }
    public void FinishJump() => isJump = !isJump;

}
