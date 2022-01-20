using SEPFramework.source.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Views.RegisterComponents
{
    public class FailureState : RegisterState
    {
        private Register registerForm;
        public FailureState(Register registerForm)
        {
            this.registerForm = registerForm;
        }
        public void OnRegister()
        {
            registerForm.setNotifyClear();
            if (!registerForm.Validate())
            {
                registerForm.NotifyValidationFailed();
                return;
            }

            if (!registerForm.Verify())
            {
                registerForm.NotifyVerificationFailed();
                return;
            }
            registerForm.RegisterState = new IdleState(registerForm);
            registerForm.OnVerificationSuccess();
        }
    }

}
