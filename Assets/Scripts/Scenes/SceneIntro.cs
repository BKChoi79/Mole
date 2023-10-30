using Common.Global;
using Common.Scene;
using UI.Menu;
using UnityEngine;

namespace Scenes
{
    public class SceneIntro : SceneBase
    {
        public UIMenuIntro menu = null;

        public override bool Init(JSONObject param)
        {
            if(menu != null)
            {
                menu.InitMenu();
            }
            

            return true;
        }

        public override void OnTouchBean(Vector3 position)
        {

        }

        public override void OnTouchEnd(Vector3 position)
        {

        }

        public override void OnTouchMove(Vector3 position)
        {

        }
    }
}

