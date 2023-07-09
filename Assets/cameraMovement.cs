using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
[SerializeField] private float moveSpeedX = 0;
[SerializeField] private float moveSpeedY = 0;

private float positionX = 0;

[SerializeField]
private float newBorderSpawn = 35f;

private float nextBorder = 0;
private float positionY = 0; 

    // Start is called before the first frame update
    void Start()
    {
        nextBorder = newBorderSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
    }
	
	void moveCamera(){
		transform.position -= new Vector3(moveSpeedX,moveSpeedY,0);
		positionX -= moveSpeedX;
		positionY -= moveSpeedY;
	}
}
