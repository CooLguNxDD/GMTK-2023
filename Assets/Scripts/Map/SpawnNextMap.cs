using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextMap : MonoBehaviour
{

    public GameObject[] mapPool;

    

    private GameObject parent;
    public int RandomIndex;
    // Start is called before the first frame update
    void Start()
    {
        if(!parent){
            parent = GameObject.Find("scrolling");
        }
    }

    // Update is called once per frame
    void Update()
    {
        int MapListLength = mapPool.Length;
        RandomIndex = Random.Range(0, MapListLength);
        Debug.Log(RandomIndex);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("hihihihasdlihokadshkljdaslhjkdashjklasdhjklasdlhjkasdhkljasdhjkl");
        
        
        if(collider.TryGetComponent(out IUnits nextUnit)){
            if(nextUnit.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT){
                GameObject nextSpawn = Instantiate(mapPool[RandomIndex], new Vector3(transform.position.x + 100, transform.position.y, 0), Quaternion.identity);
                nextSpawn.transform.SetParent(parent.transform);
                gameObject.SetActive(false);
            }
        }

    }
}
