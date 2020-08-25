using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymfoTools
{
    class FormManager
    {
        public static Form GetForm(string formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().ToString() == formType)
                {
                    return form;
                }
            }

            return Activator.CreateInstance(Type.GetType(formType)) as Form;
        }


        public static Boolean IsFormAlreadyOpen(string formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().ToString() == formType)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
