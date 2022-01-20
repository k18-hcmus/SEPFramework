using SEPFramework.source.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Views.RegisterComponents
{
    public class IdleState : RegisterState
    {
        private Register registerForm;
        public IdleState(Register registerForm)
        {
            this.registerForm = registerForm;
        }

        public void OnRegister()
        {
            if (!registerForm.Validate())
            {
                registerForm.RegisterState = new FailureState(registerForm);
                registerForm.NotifyValidationFailed();
                return;
            }

            if (!registerForm.Verify())
            {
                registerForm.RegisterState = new FailureState(registerForm);
                registerForm.NotifyVerificationFailed();
                return;
            }

            registerForm.OnVerificationSuccess();
        }
    }
}
