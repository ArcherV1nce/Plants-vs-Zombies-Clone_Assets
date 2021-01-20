using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Attacker : MonoBehaviour
{
    [SerializeField] 
    //[Range(0f, 6f)] private float movementSpeed = 1f;
    [Range(0f, 6f)] private float currentSpeed = 1f;
    //private enum state {spawn, walk, attack};
    [SerializeField] private int state = 1;

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void Update()
    {
        if (state == 1)
        { 
            transform.Translate(Vector2.left
                *  currentSpeed * Time.deltaTime);
        }
    }


}
