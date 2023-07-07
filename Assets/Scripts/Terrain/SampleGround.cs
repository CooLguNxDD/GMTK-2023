using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGround : MonoBehaviour, ITerrain
{
    [SerializeField] private ITerrain.GroundType groundType;
    public ITerrain.GroundType getGroundType()
    {
        return this.groundType;
    }
}
