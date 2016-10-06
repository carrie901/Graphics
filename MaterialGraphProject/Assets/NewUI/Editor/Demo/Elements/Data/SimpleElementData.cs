﻿using System;

namespace RMGUI.GraphView.Demo
{
	[Serializable]
	public class SimpleElementData : GraphElementData
	{
		public string title;

		protected new void OnEnable()
		{
			base.OnEnable();
			title = "simpleElement";
		}
	}
}
