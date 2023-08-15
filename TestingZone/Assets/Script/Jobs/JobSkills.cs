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
    public SkillType effectType;
    public RangeType effectRange;
    public byte skillNumber;
    public abstract void ValueReset();
    public abstract void UseSkill(List<Stats> targetStat);
}

public abstract class SkillType
{
    public float skillValue;
    public abstract void ValueSetting(float SV);
    public abstract void BuffSetting(float SV, StatType ST, Stats BT, float BD);
}
public class Dealing : SkillType
{
    //ST,BT,BD null값으로 두면 됨
    public override void ValueSetting(float SV)
    {
        skillValue = SV*-1;
    }
    public override void BuffSetting(float SV, StatType ST, Stats BT, float BD)
    {

    }
}
public class Healing : SkillType
{
    public override void ValueSetting(float SV)
    {
        skillValue = SV;
    }
    public override void BuffSetting(float SV, StatType ST, Stats BT, float BD)
    {

    }
}
public class Buff : SkillType
{
    public StatType buffStat;
    public Stats buffTarget;
    public float buffDuration;
    public override void ValueSetting(float SV)
    {
        
    }
    public override void BuffSetting(float SV, StatType ST, Stats BT, float BD)
    {
        skillValue = SV;
        buffStat = ST;
        buffTarget = BT;
        buffDuration = BD;
    }
}
public abstract class RangeType
{
    public abstract void GetRangeEffect(List<Stats> TGs);
    public abstract void AreaRadiosSet(ref float SkillRadios);
    public abstract void GetSingleEffect( Stats TG);
}
public class EffArea : RangeType
{
    public List<Stats> Targets = new List<Stats>();
    public float SkillRadios;
    public override void GetRangeEffect(List<Stats> TGs)
    {
        Targets = TGs;
    }
    public override void AreaRadiosSet( ref float SkillRadi)
    {
        SkillRadios = SkillRadi;
    }
    public override void GetSingleEffect(Stats TG)
    {

    }
}
public class EffTarget : RangeType
{
    public Stats Targets;
    public override void GetRangeEffect(List<Stats> TGs)
    {

    }
    public override void AreaRadiosSet(ref float SkillRadi)
    {

    }
    public override void GetSingleEffect(Stats TG)
    {
        Targets = TG;
    }
}
