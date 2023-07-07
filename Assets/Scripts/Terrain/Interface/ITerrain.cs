using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITerrain{
    // add type for check
    public enum GroundType{
        Normal,
        Wall,

    }
    public GroundType getGroundType();
}