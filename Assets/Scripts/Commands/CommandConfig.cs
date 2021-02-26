using System;
using UnityEngine;

[Serializable]
public class CommandConfig
{

    [SerializeField] private string id;
    [SerializeField] private Sprite icon;

    public string Id => id;

    public Sprite Icon => icon;

}
