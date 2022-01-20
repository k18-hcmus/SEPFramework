using SEPFramework.source.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Views
{
    public class FailureState : SignInState
    {
        private SignIn signInForm;
        public FailureState(SignIn signInForm)
        {
            this.signInForm = signInForm;
        }
        public void OnSignIn()
        {
            signInForm.SetNotifyClear();

            if (!signInForm.Validate())
            {
                signInForm.NotifyValidationFailed();
                return;
            }

            if (!signInForm.Verify())
            {
                signInForm.NotifyVerificationFailed();
                return;
            }

            signInForm.SignInState = new IdleState(signInForm);
            signInForm.OnVerificationSuccess();
        }
    }
}
