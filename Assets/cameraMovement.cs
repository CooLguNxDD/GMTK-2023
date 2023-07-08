using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
[SerializeField] private Camera cam;
[SerializeField] private float moveSpeedX =0;
[SerializeField] private float moveSpeedY =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	
	cam.transform.position += new Vector3(moveSpeedX,moveSpeedY,0);
        
    }
}
