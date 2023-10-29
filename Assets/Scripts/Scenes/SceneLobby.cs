using Common.Global;
using Common.Scene;
using UI.Menu;
using UnityEngine;

namespace Scenes
{
    public class SceneLobby : SceneBase
    {
        public UIMenuLobby menu = null;
        public override bool Init(JSONObject param)
        {

            if(menu != null)
            {
                menu.InitMenu();
            }

            return true;
        }


    }
}
