using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Main
{
    public class MainPanel : BasePanel
    {
        UI_MainPanel m_Panel=new UI_MainPanel();

        public override void OnEnter()
        {
            base.OnEnter();
            m_Panel.Reset(this);


        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnResume()
        {
            base.OnResume();
        }
    }
}
