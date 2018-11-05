using Labb1.Model;
using Labb1.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Subject> Subjects { get; set; }

        private ILabb1DataService _labb1DataService;
        private Subject _selectedSubject;

        public MainViewModel(ILabb1DataService labb1DataService)
        {
            Subjects = new ObservableCollection<Subject>();
            _labb1DataService = labb1DataService;
        }

        public void Load()
        {
            var subjects = _labb1DataService.GetAll();
            Subjects.Clear();

            foreach (var subject in subjects)
            {
                Subjects.Add(subject);
            }
        }

        public string WeekDay(int dayNr)
        {
            switch (dayNr)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";

                default:
                    return "Empty";
            }
        }

        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }
    }
}
