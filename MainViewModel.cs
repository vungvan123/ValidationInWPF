using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace Data_Input_Validation
{
    public class MainViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        #region disable "button submit" đến khi hết lỗi => Mở comment code thì comment lại region bên class ViewModelBase
        //Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

        //public bool HasErrors => Errors.Count > 0;

        //public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        //public IEnumerable GetErrors(string? propertyName)
        //{
        //    if (Errors.ContainsKey(propertyName))
        //    {
        //        return Errors[propertyName];
        //    }
        //    else
        //    {
        //        return Enumerable.Empty<string>();
        //    }

        //}

        //public void Validate(string propertyName, object propertyValue)
        //{
        //    var results = new List<ValidationResult>();

        //    Validator.TryValidateProperty(propertyValue, new ValidationContext(this) { MemberName = propertyName }, results);

        //    if (results.Any())
        //    {
        //        if (Errors.ContainsKey(propertyName))
        //        {
        //            Errors.Remove(propertyName);
        //        }
        //        Errors.Add(propertyName, results.Select(r => r.ErrorMessage).ToList());
        //        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //    }
        //    else
        //    {
        //        Errors.Remove(propertyName);
        //        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //    }

        //    SubmitCommand.RaiseCanExecuteChanged();
        //}

        //private string _name;

        //[Required(ErrorMessage = "Name is Required")]
        //[MaxLength(5, ErrorMessage = "Name is max length is 5")]
        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //        Validate(nameof(Name), value);
        //        RaisePropertyChanged();
        //    }
        //}

        //private string _email;

        //[Required(ErrorMessage = "Email is Required")]
        //public string Email
        //{
        //    get { return _email; }
        //    set
        //    {
        //        _email = value;
        //        Validate(nameof(Email), value);
        //        RaisePropertyChanged();
        //    }
        //}

        //private string _password;

        //[Required(ErrorMessage = "Password is Required")]
        //public string Password
        //{
        //    get { return _password; }
        //    set
        //    {
        //        _password = value;
        //        Validate(nameof(Password), value);
        //        RaisePropertyChanged();
        //    }
        //}

        //public ActionCommand SubmitCommand { get; set; }
        //public RelayCommand<string> LostFocusCommand { get; set; }

        //public MainViewModel()
        //{
        //    SubmitCommand = new ActionCommand(Submit, CanSubmit);
        //    LostFocusCommand = new RelayCommand<string>(LostFocus);

        //}

        //private void LostFocus(string obj)
        //{
        //    switch (obj)
        //    {
        //        case "Nametextbox":
        //            Validate(nameof(Name), Name);
        //            break;
        //        case "Emailtextbox":
        //            Validate(nameof(Email), Email);
        //            break;
        //        case "NamePassword":
        //            Validate(nameof(Password), Password);
        //            break;
        //    }
        //}

        //private bool CanSubmit(object obj)
        //{
        //    return Validator.TryValidateObject(this, new ValidationContext(this), null);
        //}

        //private void Submit(object obj)
        //{
        //    MessageBox.Show("Submitted");
        //}
        #endregion

        #region Ko cần disable "button submit"
        private string _name;
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(5, ErrorMessage = "Name is max length is 5")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Validate(nameof(Name), value);
                RaisePropertyChanged();
            }
        }

        private string _email;
        [Required(ErrorMessage = "Email is Required")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                Validate(nameof(Email), value);
                RaisePropertyChanged();
            }
        }

        private string _password;
        [Required(ErrorMessage = "Password is Required")]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                Validate(nameof(Password), value);
                RaisePropertyChanged();
            }
        }

        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand<string> LostFocusCommand { get; set; }

        public MainViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
            LostFocusCommand = new RelayCommand<string>(LostFocus);
        }

        private void LostFocus(string obj)
        {
            switch (obj)
            {
                case "Nametextbox":
                    Validate(nameof(Name), Name);
                    break;
                case "Emailtextbox":
                    Validate(nameof(Email), Email);
                    break;
                case "NamePassword":
                    Validate(nameof(Password), Password);
                    break;
            }
        }

        private void Submit()
        {
            var validName = Validate(nameof(Name), Name);
            var validEmail = Validate(nameof(Email), Email);
            var validPassword = Validate(nameof(Password), Password);
            if (validName && validEmail && validPassword)
            {
                MessageBox.Show("Submitted");
            }
        }

        #endregion
    }
}
