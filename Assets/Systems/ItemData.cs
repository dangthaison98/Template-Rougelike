using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [Title("Base Data", TitleAlignment = TitleAlignments.Centered)]
    public string _name;
    [MultiLineProperty]
    public string _description;
    [Min(0)]
    public int _price;
    [PreviewField(75, Alignment = ObjectFieldAlignment.Center)]
    public Sprite _icon;
}
