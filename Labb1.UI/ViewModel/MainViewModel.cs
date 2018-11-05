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

        public ObservableCollection<Subject> Subjects { get; set; }

        private Subject SelectedSubject;

        public event PropertyChangedEventHandler PropertyChanged;

        public Subject MyProperty
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
