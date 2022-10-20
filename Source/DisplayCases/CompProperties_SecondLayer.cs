using Verse;

namespace DisplayCases;

internal class CompProperties_SecondLayer : CompProperties
{
    private AltitudeLayer altitudeLayer;

    public GraphicData graphicData;

    public CompProperties_SecondLayer()
    {
        compClass = typeof(CompSecondLayer);
    }

    public float Altitude => altitudeLayer.AltitudeFor();
}