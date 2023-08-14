using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillTree
{
    public PlayerClassType JobType;
    public List<SkillFactory> skillInfo = new List<SkillFactory>();
}
public abstract class SkillFactory
{
    public ParticleSystem skillEffect;
    public SkillType EffectType;
    public EffectRange EffectRange;
    public byte SkillNumber;
    public abstract void ValueReset();
}

public abstract class SkillType
{
    public float skillValue;
}
public class Dealing : SkillType
{
    
}

public class Healing : SkillType
{
    
}
public class Buff : SkillType
{
    public StatType buffStat;
    public Stats buffTarget;
    public float buffDuration;
}
public abstract class EffectRange
{

}
public class EffArea : EffectRange
{
    public List<Stats> Targets = new List<Stats>();
}
public class EffTarget : EffectRange
{
    public float SkillRadios;
    public Stats Targets;
}
