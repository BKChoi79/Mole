using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuAntHouse : MenuBase
{
    [SerializeField]
    public Ant.Joystick Joystick = null;
    public Camera miniMapCamera = null;

    public override void OnInit()
    {

    }

    public bool InitMenu(Action<Vector3> move)
    {
        Joystick.Init((Vector3 direct, float angle) => {
            SetText("Text - Debug", $"Angle : {angle}");

            if (move != null)
            {
                move(direct);
            }
        });


        var mainCamera = AppManager.Instance.CurrScene.MainCamera;
        miniMapCamera.transform.SetParent(mainCamera.transform);
        miniMapCamera.transform.position = new Vector3(0,0,-1);

        return true;
    }


    protected override void OnClick(Button btn)
    {
        string name = btn.name;
        if (name.CompareTo("Button - Back") == 0)
        {
            AppManager.Instance.ChangeScene(SceneBase.SCENES.MENU);
        }
        else if (name.CompareTo("Button - Ok") == 0)
        {
            var scene = AppManager.Instance.CurrScene as SceneAntHouse;
            scene.RemoveTile();
        }
        else if (name.CompareTo("Button - Create") == 0)
        {
            var scene = AppManager.Instance.CurrScene as SceneAntHouse;
            scene.CreateMonster();
        }
        else if(name.CompareTo("Button - SaveGame") == 0)
        {
            var scene = AppManager.Instance.CurrScene as SceneAntHouse;
            scene.SaveGame();
        }
    }
}
