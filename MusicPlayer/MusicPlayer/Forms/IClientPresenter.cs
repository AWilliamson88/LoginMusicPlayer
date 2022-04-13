using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public interface IClientPresenter
    {
        void UpdateMenuHeader(Label menuHeader, string headerText);
        void UpdateTitle(Label Title, string titleText);
        void ResetButtonStyles(Button button);
        void RestoreButton(Button button);
        void RestoreButtons(IEnumerable<Button> buttons);
        void RemoveButtons(IEnumerable<Button> buttons);
        void ActivateButton(Button buttonToActivate);
        void ShowFormInPanel(Panel panel, Form frm);
    }
}