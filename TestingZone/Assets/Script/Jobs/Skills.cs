using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManSkill1 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        EffectType = new Dealing();
        EffectRange = new EffTarget();
        SkillNumber = 0;
    }
}
public class SwordManSkill2 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        EffectType = new Buff();
        EffectRange = new EffTarget();
        SkillNumber = 1;
    }
}
public class SwordManSkill3 : SkillFactory
{
    public override void ValueReset()
    {
        skillEffect = null;
        EffectType = new Healing();
        EffectRange = new EffTarget();
        SkillNumber = 2;
    }
}