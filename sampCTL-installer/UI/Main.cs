using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using sampCTL_installer.Internal;
using sampCTL_installer.Network;

namespace sampCTL_installer.UI
{
    partial class Main : Form
    {
        protected override CreateParams CreateParams { get { CreateParams overridecp = base.CreateParams; overridecp.ClassStyle = overridecp.ClassStyle | 0x200; return overridecp; } }
        protected UIEnvironmentHandler UIHandler;
        protected InstallationHandler INSTHandler;
        public StateHandler UIStateHandler;

        public Main()
        {
            /* Prepare UI Controls
            ------------------------*/
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            /* Initialize UI Handler
            -------------------------------*/
            UIStateHandler = new StateHandler();
            UIHandler = new UIEnvironmentHandler(this);
            {
                UIStateHandler.HandleUITransition = UIHandler.HandleUITransition;
            }

            /* Initialize Installation Handler
            -----------------------------------*/
            INSTHandler = new InstallationHandler(UIHandler, UIStateHandler);
            {
                UIStateHandler.HandleInstallation = INSTHandler.HandleInstallation;
                UIStateHandler.HandleFailureCleanup = INSTHandler.HandleFailureCleanup;
                UIStateHandler.HandleInstallationCleanup = INSTHandler.HandleInstallationCleanup;
            }
        }
        #region "Checkbox"
        private void CHKBOX_LICENSE_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKBOX_LICENSE.Checked == true)
            {
                BTN_NEXT.Enabled = true;
            }
            else
            {
                BTN_NEXT.Enabled = false;
            }
        }
        #endregion

        #region "Buttons"
        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_NEXT_Click(object sender, EventArgs e)
        {
            switch (UIStateHandler.UICurrentStatus)
            {
                case UIState.Setpath:
                {
                    INSTHandler.SetInstallationPath(TBOX_SETPATH.Text);
                    break;
                }
                case UIState.Finalize:
                {
                    Close();
                    return;
                }
            }
            UIStateHandler.TrySwitchState(UITransition.Next);
        }

        private void BTN_BACK_Click(object sender, EventArgs e)
        {
            UIStateHandler.TrySwitchState(UITransition.Back);
        }

        private void BTN_BROWSEPATH_Click(object sender, EventArgs e)
        {
            if(FBD_SETPATH.ShowDialog() == DialogResult.OK)
            {
                TBOX_SETPATH.Text = FBD_SETPATH.SelectedPath.ToString();
            }
        }
        #endregion

        #region "Link Labels"
        private void LINKLABEL_GHISSUETRACKER_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Southclaws/sampctl/issues");
        }

        private void LINKLABEL_SCTLWIKI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Southclaws/sampctl/wiki");
        }
        #endregion
    }
}
