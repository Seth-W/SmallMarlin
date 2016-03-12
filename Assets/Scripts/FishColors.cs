using UnityEngine;
using System.Collections;

public struct FishColors
{
    private Color _smallColor;
    private Color _mediumColor;
    private Color _bigColor;

    public Color smallColor
    {
        get { return _smallColor; }
        set { _smallColor = value; }
    }
    public Color mediumColor
    {
        get { return _mediumColor; }
        set { _mediumColor = value; }
    }
    public Color bigColor
    {
        get { return _bigColor; }
        set { _bigColor = value; }
    }
    public Color testColor;
}
