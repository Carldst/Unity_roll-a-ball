using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    
    void Update()
    {
        // Rotate the game object 
        transform.Rotate(new Vector3(0, 90, 90) * Time.deltaTime);
    }
}
