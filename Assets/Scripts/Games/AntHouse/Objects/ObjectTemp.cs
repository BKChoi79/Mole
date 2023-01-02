using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTemp : ObjectBase
{
    public SpriteRenderer sprite = null;
    protected override bool LoadSprite()
    {
        var prefab = ResourcesManager.Instance.LoadInBuild<SpriteRenderer>("Ant/ObjectSprite");
        sprite = Instantiate<SpriteRenderer>(prefab, transform);

        return true;
    }
}
