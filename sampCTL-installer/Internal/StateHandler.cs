using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stateless;
using sampCTL_installer.UI;

namespace sampCTL_installer.Internal
{
    #region "Begin UI State Definitions"
    public enum UIState
    {
        Init,
        License,
        Setpath,
        Install,
        Finalize
    }

    public enum UITransition
    {
        Next,
        Back,
        Cancel,
        Failure,
    }
    #endregion

    class StateHandler
    {
        public UIState UICurrentStatus { get { return UI_State.State; } }
        private StateMachine<UIState, UITransition> UI_State;
        public Action<StateMachine<UIState, UITransition>.Transition> HandleUITransition { get; set; } = (x) => { };
        public Action HandleInstallation { get; set; } = () => { };
        public Action HandleInstallationCleanup { get; set; } = () => { };
        public Action HandleFailureCleanup { get; set; } = () => { };

        public StateHandler()
        {
            CreateTransitionRuleset();
        }

        public bool TrySwitchState(UITransition Transition)
        {
            if (UI_State.CanFire(Transition))
            {
                UI_State.Fire(Transition);
                return true;
            }
            else return false;
        }

        private void CreateTransitionRuleset()
        {
            UI_State = new StateMachine<UIState, UITransition>(UIState.Init);

            UI_State.Configure(UIState.Init)
                .Permit(UITransition.Next, UIState.License);

            UI_State.Configure(UIState.License)
                .Permit(UITransition.Back, UIState.Init)
                .Permit(UITransition.Next, UIState.Setpath);

            UI_State.Configure(UIState.Setpath)
                .Permit(UITransition.Back, UIState.License)
                .Permit(UITransition.Next, UIState.Install);

            UI_State.Configure(UIState.Install)
                .Permit(UITransition.Next, UIState.Finalize)
                .Permit(UITransition.Failure, UIState.Finalize)
                .OnEntryFrom(UITransition.Next, () => HandleInstallation());

            UI_State.Configure(UIState.Finalize)
                .OnEntryFrom(UITransition.Next, () => HandleInstallationCleanup())
                .OnEntryFrom(UITransition.Failure, () => HandleFailureCleanup());

            UI_State.OnTransitioned((x) => { if (x.Destination != UIState.Finalize) { HandleUITransition(x); } });
        }
    }
}
