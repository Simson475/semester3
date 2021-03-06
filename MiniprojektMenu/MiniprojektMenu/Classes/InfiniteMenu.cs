﻿namespace MiniprojektMenu
{
    class InfiniteMenu : Menu, IMenuPoints
    {
        public InfiniteMenu(string title) : base(title) { }
        public override void Select()
        {
            for (int i = 0; i < 6; i++)
            {
                Content.Add(new InfiniteMenu($"Infinite {i + 1}"));
            }
            base.Select();
        }

    }
}
