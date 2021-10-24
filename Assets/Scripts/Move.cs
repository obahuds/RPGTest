using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase BaseDetails { get; set; }
    public int PP { get; set; }

    public Move(MoveBase baseDetails) { 
        BaseDetails = baseDetails; 
        PP = BaseDetails.Pp; 
    }

}
