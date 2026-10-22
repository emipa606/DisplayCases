using RimWorld;
using Verse;

namespace DisplayCases;

internal sealed class CompSecondLayer : ThingComp
{
    private CompProperties_SecondLayer Props => (CompProperties_SecondLayer)props;

    private Graphic Graphic
    {
        get
        {
            if (field != null)
            {
                return field;
            }

            if (Props.graphicData == null)
            {
                Log.ErrorOnce($"{parent.def} has no SecondLayer graphicData but we are trying to access it.",
                    764532);
                return BaseContent.BadGraphic;
            }

            field = Props.graphicData.GraphicColoredFor(parent);

            return field;
        }
    }

    public override void PostDraw()
    {
        base.PostDraw();
        Graphic.Draw(GenThing.TrueCenter(parent.Position, parent.Rotation, parent.def.size, Props.Altitude),
            parent.Rotation, parent);
    }
}