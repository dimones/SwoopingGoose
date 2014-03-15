using UnityEngine;
using System.Collections;

public class wallAction : MonoBehaviour {

    void Update()
    {
       Transform  _transWall = GameObject.FindGameObjectWithTag("wallAction1").transform;
       Transform _transWall2 = GameObject.FindGameObjectWithTag("wallAction2").transform;
       Rigidbody2D _body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
       if ((int)_transWall.position.x == (int)_body.transform.position.x)
       {
           GameObject.FindGameObjectWithTag("Player").GetComponent<SGGooseController>()._dir = SGGooseController.Direction.Left;
       }
       if ((int)_transWall2.position.x == (int)_body.transform.position.x)
       {
           GameObject.FindGameObjectWithTag("Player").GetComponent<SGGooseController>()._dir = SGGooseController.Direction.Right;
       }
    }
}
