using Labb1.Model;
using Labb1.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Labb1.UI.ViewModel;

namespace Labb1.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Todo: adicionar e remover rows na database
        // poder escrever o conteudo
        // poder editar o que esta escrito no subjectinfo

        public ObservableCollection<WeekNr> MainCollection { get; set; }
        public ObservableCollection<Subject> SubjectsCollection { get; set; }
        public ObservableCollection<WeekDay> WeekDaysCollection { get; set; }
        public ObservableCollection<WeekNr> WeekListCollection { get; set; }

        private ILabb1DataService _labb1DataService;
        private Subject _selectedSubject;
        private WeekDay _selectedWeekDay;
        private WeekNr _selectedWeekNr;

        private System.Windows.Controls.ComboBox DayComboBox;

        public MainViewModel(ILabb1DataService labb1DataService)
        {
            MainCollection = new ObservableCollection<WeekNr>();
            SubjectsCollection = new ObservableCollection<Subject>();
            WeekDaysCollection = new ObservableCollection<WeekDay>();
            WeekListCollection = new ObservableCollection<WeekNr>();

            _labb1DataService = labb1DataService;
        }

        public void Load()
        {
            var weeknrs = _labb1DataService.GetAll();

            MainCollection.Clear();
            SubjectsCollection.Clear();
            WeekDaysCollection.Clear();

            foreach (var weekcontent in weeknrs)
            {
                MainCollection.Add(weekcontent);
                SubjectsCollection.Add(weekcontent.WeekDay.Subject);
            }

            CopyWeeksFromMainListAndRemoveDuplicates(weeknrs);
        }

        private void CopyWeeksFromMainListAndRemoveDuplicates(IEnumerable<WeekNr> weekNrs)
        {
            List<WeekNr> convertToList = weekNrs.ToList();

            for (int i = 0; i < convertToList.Count; i++)
            {
                var obj = WeekListCollection.SingleOrDefault(s => s.WeekNumber == convertToList[i].WeekNumber);

                if (!WeekListCollection.Any())
                {
                    WeekListCollection.Add(convertToList[i]);
                }
                else if (obj == null)
                {
                    WeekListCollection.Add(convertToList[i]);
                }
                obj = null;
            }
        }

        private void DaysToDisplay()
        {
            //se eu selecionar uma semana imprimir(adicionar para imprimir) dias que terao aula naquela semana
            if (WeekDaysCollection.Count > 0)
                WeekDaysCollection.Clear();

            foreach (var item in MainCollection)
            {
                if (item.WeekNumber == _selectedWeekNr.WeekNumber)
                {
                    WeekDaysCollection.Add(item.WeekDay);
                }
            }

            //for (int i = 0; i < MainCollection.Count; i++)
            //{
            //    var obj = WeekDaysCollection.SingleOrDefault(s => s. == MainCollection[i].WeekNumber);

            //    if (!WeekDaysCollection.Any())
            //    {
            //        WeekDaysCollection.Add(MainCollection[i]);
            //    }
            //    else if (obj == null)
            //    {
            //        WeekDaysCollection.Add(MainCollection[i]);
            //    }
            //    obj = null;
            //}
        }

        #region Props

        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        public WeekDay SelectedWeekDay
        {
            get { return _selectedWeekDay; }
            set
            {
                _selectedWeekDay = value;

                OnPropertyChanged();
            }
        }

        public WeekNr SelectedWeekNr
        {
            get { return _selectedWeekNr; }
            set
            {
                _selectedWeekNr = value;
                DaysToDisplay();
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
