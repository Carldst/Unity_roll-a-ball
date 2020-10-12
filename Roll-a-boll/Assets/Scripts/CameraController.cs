using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]    //it appears in Unity interface but is private
    private GameObject player; //used to have position of the player

    private Vector3 offset; //store the offset value

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //calculate only once
    }

    void LateUpdate() //to make sure, camera move last
    {
        transform.position = player.transform.position + offset;
    }
}