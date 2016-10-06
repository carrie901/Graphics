using UnityEngine;
using UnityEngine.RMGUI;

namespace RMGUI.GraphView
{
	public class GraphElement : DataContainer, ISelectable
	{
		public override void OnDataChanged()
		{
			var data = GetData<GraphElementData>();
			if (data == null)
			{
				return;
			}

			// propagate selection but why?
			foreach (VisualElement ve in children)
			{
				GraphElement ce = ve as GraphElement;
				if (ce != null)
				{
					var childData = ce.dataProvider as GraphElementData;
					if (childData != null)
					{
						childData.selected = data.selected;
					}
				}
			}

			// set absolute position from data
			position = data.position;
		}

		public virtual bool IsSelectable()
		{
			var data = GetData<GraphElementData>();
			if (data != null)
			{
				return (data.capabilities & Capabilities.Selectable) == Capabilities.Selectable;
			}
			return false;
		}

		public virtual Vector3 GetGlobalCenter()
		{
			var center = position.center;
			var globalCenter = new Vector3(center.x + parent.position.x, center.y + parent.position.y);
			return parent.globalTransform.MultiplyPoint3x4(globalCenter);
		}
	}
}
