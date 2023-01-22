using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    //Room Camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity= Vector3.zero;

    //Follow Player
    [SerializeField] private Transform Player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private void Update()
    {   
        //Room Camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),ref velocity,speed);

        //Follow Player.
        transform.position = new Vector3(Player.position.x,transform.position.y,transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Player.localScale.x),Time.deltaTime*cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX=_newRoom.position.x;
    }
}
