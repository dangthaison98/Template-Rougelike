using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ItemData
{
    [Title("Weapon Type", TitleAlignment = TitleAlignments.Centered), OnValueChanged(nameof(GetColor)), Space(20)]
    public WeaponRarity rarity;
    [ReadOnly, HideLabel]
    public Color rarityColor;

    [EnumToggleButtons]
    public CostType costType;
    [ShowIf("costType", CostType.Mana)]
    public int manaCost;
    [ShowIf("costType", CostType.Bullet)]
    public int maxBullet;
    [ShowIf("costType", CostType.Blood)]
    public int heathCost;
    [ShowIf("costType", CostType.Money)]
    public int moneyCost;

    [Title("Stat", TitleAlignment = TitleAlignments.Centered), Space(20)]
    public DamageType damageType;

    [ShowIf("damageType", DamageType.Physic), Min(0)]
    public int physicDamage;
    [ShowIf("damageType", DamageType.Physic), Range(0, 100), SuffixLabel("%")]
    public int armorPenetration;
    [ShowIf("damageType", DamageType.Physic), Range(0, 100), SuffixLabel("%")]
    public int physicalVamp;

    [ShowIf("damageType", DamageType.Magic), Min(0)]
    public int magicDamage;
    [ShowIf("damageType", DamageType.Magic), Range(0, 100), SuffixLabel("%")]
    public int magicPenetration;
    [ShowIf("damageType", DamageType.Magic), Range(0, 100), SuffixLabel("%")]
    public int spellVamp;

    [ShowIf("damageType", DamageType.True), Min(0)]
    public int trueDamage;

    [Tooltip("Attacks per second"), Min(0), SuffixLabel("/s")]
    public float attackSpeed;
    [HideIf("damageType", DamageType.None), Range(0, 100), SuffixLabel("%")]
    public int criticalStrikeChance;
    [HideIf("damageType", DamageType.None), Min(150), SuffixLabel("%")]
    public int criticalStrikeDamage = 150;

    private void GetColor()
    {
        switch(rarity)
        {
            case WeaponRarity.Common: rarityColor = Color.white; break;
            case WeaponRarity.Uncommon: rarityColor = Color.green; break;
            case WeaponRarity.Rare: rarityColor = Color.blue; break;
            case WeaponRarity.Epic: rarityColor = new Color(0.5f, 0f, 0.5f); break;
            case WeaponRarity.Legendary: rarityColor = new Color(1f, 0.65f, 0f); break;
            case WeaponRarity.Mythical: rarityColor = Color.red; break;
            case WeaponRarity.Exotic: rarityColor = Color.cyan; break;
        }
    }
}

public enum WeaponRarity
{
    Common, Uncommon, Rare, Epic, Legendary, Mythical, Exotic
}
public enum CostType
{
    None, Mana, Bullet, Blood, Money
}
public enum DamageType
{
    None,
    Physic,
    Magic,
    True
}
