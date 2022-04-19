using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public class ClientPresenter : IClientPresenter
    {
        public void UpdateMenuHeader(Label menuHeader, string headerText)
        {
            if (!string.IsNullOrEmpty(headerText))
                menuHeader.Text = headerText;
        }
        public void UpdateTitle(Label Title, string titleText)
        {
            if (!string.IsNullOrEmpty(titleText))
                Title.Text = titleText;
        }

        #region Buttons

        /// <summary>
        /// Resets the buttons font, back colour, and fore colour.
        /// </summary>
        /// <param name="button">The button whose styles to reset.</param>
        public void ResetButtonStyles(Button button)
        {
            button.BackColor = Color.FromArgb(64, 64, 64);
            button.ForeColor = Color.WhiteSmoke;
            button.Font = new Font("Microsoft Sans Serif", 12F);
        }

        /// <summary>
        /// Sets the buttons enabled property to true and 
        /// then calls it's show function.
        /// </summary>
        /// <param name="button">The button whose functionality
        /// you wish to restore</param>
        /// <returns></returns>
        public void RestoreButton(Button button)
        {
            button.Enabled = true;
            button.Show();
        }
        /// <summary>
        /// Sets each of the buttons enabled propertys to true and 
        /// then calls their show functions. 
        /// </summary>
        /// <param name="buttons"></param>
        public void RestoreButtons(IEnumerable<Button> buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Show();
            }
        }

        public void RemoveButtons(IEnumerable<Button> buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
                button.Hide();
            }
        }

        /// <summary>
        /// Will change the button to appear active and 
        /// will asign it as the current button
        /// </summary>
        /// <param name="currentBtn">The current button property to reasign</param>
        /// <param name="buttonToActivate">The button to activate.</param>
        public void ActivateButton(Button buttonToActivate)
        {
            buttonToActivate.BackColor = Color.FromArgb(67, 183, 110);
            buttonToActivate.ForeColor = Color.White;
            buttonToActivate.Font = new Font("Microsoft Sans Serif", 14F);
        }

        #endregion

        #region Forms
        public void ShowFormInPanel(Panel panel, Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel.Controls.Add(frm);
            panel.Tag = frm;
            frm.BringToFront();
            frm.Visible = true;

        }

        #endregion
    }
}
