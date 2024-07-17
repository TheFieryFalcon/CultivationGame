using System;
namespace Enums
{
    public enum Item
    {
        SpiritGinseng,
        HeartLotus,
        QiCondensationPill,
        MeridianWideningPill,
        FoundationBuildingPill
    }
    public enum ItemType
    {
        Herb,
        Pill,
        Misc
    }
    public enum Location
    {
        Swamp
    }
    public enum Grade
    {
        Mortal,
        Yellow,
        Mysterious,
        Earth,
        Heaven,
        Fairy,
        Immortal,
        Ancient,
        Transcendant,
        Origin

    }
    public enum Quality
    {
        Useless = 0,
        Trash = 3,
        Bad = 10,
        Ordinary = 20,
        Decent = 50
    }
}
