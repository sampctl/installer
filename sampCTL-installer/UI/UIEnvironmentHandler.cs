using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sampCTL_installer.Internal;
using Stateless;

namespace sampCTL_installer.UI
{
    class UIEnvironmentHandler : Main
    {
        private Main UIHandle;
        public UIEnvironmentHandler(Main MainUIHandle)
        {
            //Hack to ease our lives because why not.
            UIHandle = MainUIHandle;
        }

        public void HandleUITransition(StateMachine<UIState, UITransition>.Transition Transition)
        {
            switch (Transition.Destination)
            {
                case UIState.Init:
                {
                    ShowPanel(PANEL_INIT_FULL);
                    PrepareUI(UIHandle.UIStateHandler.UICurrentStatus);
                    break;
                }

                case UIState.License:
                {
                    ShowPanel(PANEL_LICENSE_FULL);
                    PrepareUI(UIHandle.UIStateHandler.UICurrentStatus);
                    break;
                }

                case UIState.Setpath:
                {
                    ShowPanel(PANEL_SETPATH_FULL);
                    PrepareUI(UIHandle.UIStateHandler.UICurrentStatus);
                    break;
                }

                case UIState.Install:
                {
                    ShowPanel(PANEL_INSTALL_FULL);
                    PrepareUI(UIHandle.UIStateHandler.UICurrentStatus);
                    break;
                }
            }
        }

        #region "CrossThread Operations"
        public void UpdateUIProgressControls(string Text, bool newline = true, bool updatelabel = false)
        {
            if (UIHandle.InvokeRequired)
            {
                UIHandle.Invoke(new MethodInvoker(() =>
                {
                    UIHandle.RTB_PROGRESS.AppendText((newline) ? (Environment.NewLine +  DateTime.Now.ToString() + ": " + Text) : (DateTime.Now.ToString() + ": " + Text));
                    if (updatelabel)
                    {
                        UIHandle.LABEL_INSTALL_PROGRESS.Text = Text;
                    }
                }));
            }
            else
            {
                UIHandle.RTB_PROGRESS.AppendText((newline) ? (Environment.NewLine + DateTime.Now.ToString() + ": " + Text) : (DateTime.Now.ToString() + ": " + Text));
                if (updatelabel)
                {
                    UIHandle.LABEL_INSTALL_PROGRESS.Text = Text;
                }
            }
        }

        public void ExitInstallation(bool success, string finalmsg = null)
        {
            if (success)
            {
                if (UIHandle.InvokeRequired)
                {
                    UIHandle.Invoke(new MethodInvoker(() => 
                    {
                        PrepareUI(UIState.Finalize);
                        UIHandle.UIStateHandler.TrySwitchState(UITransition.Next);
                    }));
                }
                else
                {
                    PrepareUI(UIState.Finalize);
                    UIHandle.UIStateHandler.TrySwitchState(UITransition.Next);
                }
            }
            else
            {
                if (UIHandle.InvokeRequired)
                {
                    UIHandle.Invoke(new MethodInvoker(() =>
                    {
                        PrepareFailureUI(finalmsg);
                        UIHandle.UIStateHandler.TrySwitchState(UITransition.Failure);
                    }));
                }
                else
                {
                    PrepareFailureUI(finalmsg);
                    UIHandle.UIStateHandler.TrySwitchState(UITransition.Failure);
                }
            }
        }
        #endregion

        private void ShowPanel(Panel Panel)
        {
            foreach (var UIPanel in UIHandle.Controls.OfType<Panel>().Where(P => P.Name.Contains("_FULL")))
            {
                UIPanel.Visible = UIPanel.Name == Panel.Name;
            }
        }

        private void PrepareUI(UIState State)
        {
            switch(State)
            {
                case UIState.Init:
                {
                    UIHandle.BTN_BACK.Enabled = false;
                    UIHandle.BTN_NEXT.Enabled = true;
                    UIHandle.BTN_CANCEL.Enabled = true;
                    break;
                }

                case UIState.License:
                {
                    UIHandle.BTN_BACK.Enabled = true;
                    UIHandle.BTN_NEXT.Enabled = false;
                    UIHandle.BTN_CANCEL.Enabled = true;
                    
                    UIHandle.CHKBOX_LICENSE.Checked = false;
                    UIHandle.RTB_LICENSE.SelectAll();
                    UIHandle.RTB_LICENSE.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                }

                case UIState.Setpath:
                {
                    UIHandle.BTN_BACK.Enabled = true;
                    UIHandle.BTN_NEXT.Enabled = true;
                    UIHandle.BTN_CANCEL.Enabled = true;
                    break;
                }

                case UIState.Install:
                {
                    UIHandle.BTN_BACK.Enabled = false;
                    UIHandle.BTN_NEXT.Enabled = false;
                    UIHandle.BTN_CANCEL.Enabled = false;
                    break;
                }

                case UIState.Finalize:
                {
                    UIHandle.BTN_BACK.Enabled = false;
                    UIHandle.BTN_NEXT.Enabled = true;
                    UIHandle.BTN_CANCEL.Enabled = false;
                    UIHandle.BTN_NEXT.Text = "Finish";
                    ShowPanel(PANEL_FINALIZE_FULL);
                    break;
                }
            }
        }

        private void PrepareFailureUI(string FailureMSG)
        {
            PrepareUI(UIState.Finalize);
            ShowPanel(PANEL_FINALIZE_FULL);
            UIHandle.LABEL_FINALIZE_TITLE.Text = "Installation aborted! an error occurred";
            UIHandle.LABEL_FINALIZE_DESC.Text = "Operation aborted due to the following error: \r\n" + FailureMSG;
        }
    }
}
