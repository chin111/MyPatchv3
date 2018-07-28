using MyPatchV3.UI.ViewModels.Base;
using System;

namespace MyPatchV3.UI.Models
{
    public class Employee : ExtendedBindableObject
    {
        private bool _isSelected;

        public int Id { get; set; }

        public string Employee_ID { get; set; }

        public string Name { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }
    }
}
