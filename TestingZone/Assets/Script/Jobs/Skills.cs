using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManSkill1 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        effectType = new Dealing();
        effectType.ValueSetting(100);
        effectRange = new EffArea();
        effectRange.AreaRadiosSet(2);
        skillNumber = 0;
    }
    public override void UseSkill(List<Stats> targets)
    {
        if(targets.Count == 1)
        {
            effectRange.GetSingleEffect(targets[0]);
        }
        else
        {
            effectRange.GetRangeEffect(targets);
            //액션을 쓰는것도 방법일듯?
        }
    }
}
public class SwordManSkill2 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        effectType = new Buff();
        effectRange = new EffArea();
        effectRange.AreaRadiosSet(2);
        skillNumber = 1;
    }
    public override void UseSkill(List<Stats> targets)
    {

    }
}
public class SwordManSkill3 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        effectType = new Healing();
        effectRange = new EffTarget();
        skillNumber = 2;
    }
    public override void UseSkill(List<Stats> targets)
    {

    }
}
public class SwordManSkill4 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        effectType = new Healing();
        effectRange = new EffTarget();
        skillNumber = 3;
    }
    public override void UseSkill(List<Stats> targets)
    {

    }
}