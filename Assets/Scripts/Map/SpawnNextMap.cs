using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextMap : MonoBehaviour
{

    public GameObject[] mapPool;

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("hihihihasdlihokadshkljdaslhjkdashjklasdhjklasdlhjkasdhkljasdhjkl");

        if(collider.TryGetComponent(out IUnits nextUnit)){
            if(nextUnit.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT){
                GameObject nextSpawn = Instantiate(mapPool[0], new Vector3(transform.position.x + 100, transform.position.y, 0), Quaternion.identity);
                nextSpawn.transform.SetParent(parent.transform);
                gameObject.SetActive(false);
            }
        }

    }
}
