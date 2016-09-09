namespace RogueAPI.Game
{
    public enum LevelRenderStep
    {
        RoomBgToBack = 1,
        SkyBackToFront = 2,
        RoomBgToFront = 3,
        RoomFgToFront = 4,
        InvertFrontToBack = 5,
        SaturateBackToFront = 6,
        PlayerObjectsToFront = 7,
        TextToFront = 8,
        DarknessToFront = 9,
        HUDToFront = 10,
        BorderToFront = 11,
        ExtraFrontToBack = 12,
        NostalgiaBackToFront = 13,
        NostalgiaFrontToBack = 14,
        BackToScreenFinal = 20
    }
}
