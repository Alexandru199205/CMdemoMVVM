using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
   public class ShellViewModel : Conductor<object>
    {
        private string  _firstName="Alex";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;
        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Alex", LastName = "Bacescu" });
            People.Add(new PersonModel { FirstName = "Agnes", LastName = "Bacescu" });
            People.Add(new PersonModel { FirstName = "Andrei", LastName = "Sarbu" });
        }
        public string FirstName
        {
            get
            {
                return _firstName; 
            }
            set 
            { _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get {
                return _lastName;
            }
            set {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
                
        public string FullName
        {
            get { return $"{FirstName} {LastName }"; }
        }
        

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; } 
            set { 
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        
        }
        public bool CanClearText(string firstName, string lastName)
        {
            // return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
            //the bellow expresion is more readable the the above one!!!
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            return true;
        }

        public void ClearText (string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
            
        }

        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
}
