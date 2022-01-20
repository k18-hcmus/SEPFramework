using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.Utils.IoCContainer;
using SEPFramework.source.views;
using SEPFramework.source.Views;

namespace SEPFramework.source.Views
{
    public class IdleState : SignInState
    {
        private SignIn signInForm;
        public IdleState(SignIn signInForm)
        {
            this.signInForm = signInForm;
        }
        public void OnSignIn()
        {
            if (!signInForm.Validate())
            {
                signInForm.SignInState = IoC.Resolve<FailureState>(new InjectionConstructor().AddParameter<SignIn>(signInForm));
                signInForm.NotifyValidationFailed();
                return;
            }

            if (!signInForm.Verify())
            {
                signInForm.SignInState = IoC.Resolve<FailureState>(new InjectionConstructor().AddParameter<SignIn>(signInForm));
                signInForm.NotifyVerificationFailed();
                return;
            }
            
            signInForm.OnVerificationSuccess();
        }
    }
}
