using RimWorld;
using System;
using Verse;

namespace DisplayCases
{
	// Token: 0x02000002 RID: 2
	internal class CompSecondLayer : ThingComp
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public CompProperties_SecondLayer Props
		{
			get
			{
				return (CompProperties_SecondLayer)this.props;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002070 File Offset: 0x00000270
		public virtual Graphic Graphic
		{
			get
			{
				bool flag = this.graphicInt == null;
				if (flag)
				{
					bool flag2 = this.Props.graphicData == null;
					if (flag2)
					{
						Log.ErrorOnce(this.parent.def + " has no SecondLayer graphicData but we are trying to access it.", 764532);
						return BaseContent.BadGraphic;
					}
					this.graphicInt = this.Props.graphicData.GraphicColoredFor(this.parent);
				}
				return this.graphicInt;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020F0 File Offset: 0x000002F0
		public override void PostDraw()
		{
			base.PostDraw();
			this.Graphic.Draw(GenThing.TrueCenter(this.parent.Position, this.parent.Rotation, this.parent.def.size, this.Props.Altitude), this.parent.Rotation, this.parent);
		}

		// Token: 0x04000001 RID: 1
		private Graphic graphicInt;
	}
}
