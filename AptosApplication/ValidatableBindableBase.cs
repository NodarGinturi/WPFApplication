﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AptosApplication
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else
                return null;
        }

        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty(ref member, val, propertyName);
            ValidateProperty(propertyName, val);
        }

        private void ValidateProperty<T>(string propertyName, T val)
        {
            //var result = new List<ValidationResult>();
            //ValidationContext context = new ValidationContext(this);
            //Validator.TryValidateProperty(val, context, result);
            //if (result.Any())
            //    _errors[propertyName] = result.Select(c => c.ErrorMessage).ToList();
            //else
            //    _errors.Remove(propertyName);
            //ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
