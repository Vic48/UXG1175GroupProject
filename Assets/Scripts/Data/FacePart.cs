using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePart
{
    //Ref Data (this class should have no Dyn data unless game design changed)
    private string refId;
    private string partName;
    private string assetName;
    private PartType partType;

    public FacePart(string refId, string name, string assetName, PartType type)
    {
        this.refId = refId;
        this.partName = name;
        this.assetName = assetName;
        this.partType = type;
    }

    public string GetRefId()
    {
        return refId;
    }

    public string GetPartName()
    {
        return partName;
    }

    public string GetAssetName()
    {
        return assetName;
    }

    public PartType GetPartType()
    {
        return partType;
    }
}


//Child classes
public class PartShape : FacePart
{
    public PartShape(string id, string name, string desc) : base(id, name, desc, PartType.SHAPE) { }
}

public class PartEyes : FacePart
{
    public PartEyes(string id, string name, string desc) : base(id, name, desc, PartType.EYES) { }
}

public class PartNose : FacePart
{
    public PartNose(string id, string name, string desc) : base(id, name, desc, PartType.NOSE) { }
}

public class PartMouth : FacePart
{
    public PartMouth(string id, string name, string desc) : base(id, name, desc, PartType.MOUTH) { }
}

//Part type enum
public enum PartType
{
    SHAPE,
    EYES,
    NOSE,
    MOUTH
}