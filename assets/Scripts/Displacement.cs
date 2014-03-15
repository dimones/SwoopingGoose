using UnityEngine;
using System.Collections;

public class Displacement : MonoBehaviour
{

    //Check the number that moves
    public float displacement = -5;


    void Update()
    {

        //Changes the position of the object in its x axis offset selected
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + displacement, Time.deltaTime), transform.position.y, transform.position.z);
    }
}
