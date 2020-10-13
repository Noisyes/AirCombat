using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    [BindPrefab(Paths.START_VIEW)]
    public class StartView : ViewBase
    {
        protected override void InitChild()
        {
            UIUtil.Get("Start").AddListener(() =>
            {
                UIMgr.Instance.Show(Paths.SELECTEDHERO_VIEW);
            });
        }
    }
}

