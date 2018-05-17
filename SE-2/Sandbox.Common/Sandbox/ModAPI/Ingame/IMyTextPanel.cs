namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using VRage.Game.GUI.TextPanel;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyTextPanel : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void AddImagesToSelection(List<string> ids, bool checkExistence = false);
        void AddImageToSelection(string id, bool checkExistence = false);
        void ClearImagesFromSelection();
        void GetFonts(List<string> fonts);
        [Obsolete("LCD private text is deprecated")]
        string GetPrivateText();
        [Obsolete("LCD private text is deprecated")]
        string GetPrivateTitle();
        string GetPublicText();
        string GetPublicTitle();
        void GetSelectedImages(List<string> output);
        void ReadPublicText(StringBuilder buffer, bool append = false);
        void RemoveImageFromSelection(string id, bool removeDuplicates = false);
        void RemoveImagesFromSelection(List<string> ids, bool removeDuplicates = false);
        void SetShowOnScreen(ShowTextOnScreenFlag set);
        [Obsolete("LCD private text is deprecated")]
        void ShowPrivateTextOnScreen();
        void ShowPublicTextOnScreen();
        void ShowTextureOnScreen();
        [Obsolete("LCD private text is deprecated")]
        bool WritePrivateText(string value, bool append = false);
        [Obsolete("LCD private text is deprecated")]
        bool WritePrivateTitle(string value, bool append = false);
        bool WritePublicText(string value, bool append = false);
        bool WritePublicText(StringBuilder value, bool append = false);
        bool WritePublicTitle(string value, bool append = false);

        Color BackgroundColor { get; set; }

        float ChangeInterval { get; set; }

        string CurrentlyShownImage { get; }

        string Font { get; set; }

        Color FontColor { get; set; }

        float FontSize { get; set; }

        ShowTextOnScreenFlag ShowOnScreen { get; }

        bool ShowText { get; }
    }
}

