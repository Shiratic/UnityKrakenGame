using UnityEngine;
using System;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon1,
    Weapon2,
    Accessory1,
    Accessory2,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float VitalityPercentBonus;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character stats)
    {
        if (StrengthBonus != 0)
            stats.stats[(int)Attributes.STR].AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            stats.stats[(int)Attributes.DEX].AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        if (IntelligenceBonus != 0)
            stats.stats[(int)Attributes.INT].AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        if (VitalityBonus != 0)
            stats.stats[(int)Attributes.VIT].AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));

        if (StrengthPercentBonus != 0)
            stats.stats[(int)Attributes.STR].AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            stats.stats[(int)Attributes.DEX].AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        if (IntelligencePercentBonus != 0)
            stats.stats[(int)Attributes.INT].AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        if (VitalityPercentBonus != 0)
            stats.stats[(int)Attributes.VIT].AddModifier(new StatModifier(VitalityPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character stats)
    {
        stats.stats[(int)Attributes.STR].RemoveAllModifiersFromSource(this);
        stats.stats[(int)Attributes.DEX].RemoveAllModifiersFromSource(this);
        stats.stats[(int)Attributes.INT].RemoveAllModifiersFromSource(this);
        stats.stats[(int)Attributes.VIT].RemoveAllModifiersFromSource(this);
    }
}