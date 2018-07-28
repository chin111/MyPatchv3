using MyPatchV3.UI.Controls.Cells;
using Xamarin.Forms;

namespace MyPatchV3.UI.TemplateSelectors
{
    public class EmployeeDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _employeeDataTemplate;

        public EmployeeDataTemplateSelector()
        {
            _employeeDataTemplate = new DataTemplate(typeof(EmployeeCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return _employeeDataTemplate;
        }
    }
}
