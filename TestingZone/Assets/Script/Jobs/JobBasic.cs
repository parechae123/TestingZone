using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerClassType
{
    SwordMan, Mage, Priest, Thief, Merchant
}
public abstract class PlayerJobs
{
    public PlayerClassType Job;
    public Mesh JobModel;
    public Material JobModelMat;
}
