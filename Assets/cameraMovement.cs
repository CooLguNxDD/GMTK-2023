using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
[SerializeField] private Camera cam;
[SerializeField] private float moveSpeedX =0;
[SerializeField] private float moveSpeedY =0;
private float positionX = 0;
private float positionY = 0; 

    // Start is called before the first frame update
 void Start()
    {
        
   }

    // Update is called once per frame
void Update()
    {
	
	moveCamera();
	inGameEvent();
        
   }
	
	void moveCamera(){
		cam.transform.position += new Vector3(moveSpeedX,moveSpeedY,0);
		positionX += moveSpeedX;
		positionY += moveSpeedY;
	}
	
	void inGameEvent()
	{
		int enemyHealth = 0;
	
		if (enemyHealth <= 0){
	
		}
	
		else if (positionX > 20)
		{
		cam.transform.position -= new Vector3(moveSpeedX,moveSpeedY,0);
		positionX -= moveSpeedX;
		}
	
	}
	

}
