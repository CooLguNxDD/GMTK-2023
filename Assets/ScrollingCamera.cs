using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour
{
[SerializeField] private float scrollingSpeed;
 private Vector3 scroll; 
[SerializeField] private Camera cam; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
	
	private void MoveCamera()
	{
		scroll = new Vector3(scrollingSpeed,0,-10);
		cam.transform.position += scroll;
	
	}
}
