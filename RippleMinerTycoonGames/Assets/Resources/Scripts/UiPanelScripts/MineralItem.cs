using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Main
{
    public class MineralItem : BasePanel
    {
        Item_MineralItem m_Item =new Item_MineralItem();

        public override void OnEnter()
        {
            base.OnEnter();
            m_Item.Reset(this);
        }
        public void Init()
        { 
        
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
