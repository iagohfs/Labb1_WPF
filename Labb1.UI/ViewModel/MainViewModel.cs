using Labb1.Model;
using Labb1.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Labb1_Wpf.DataAccess;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Input;
using System;

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
        private SubjectOrganizerDbContext SubjectOrganizerDbContext;

        private Subject _selectedSubject;
        private WeekDay _selectedWeekDay;
        private WeekNr _selectedWeekNr;
        private IEnumerable<WeekNr> weeknrs;

        internal string CurrentText(string PrintedText)
        {
            string toreturn = "";

            for (int i = 0; i < SubjectsCollection.Count; i++)
            {
                if (SubjectsCollection[i].SubjectInfo == PrintedText)
                {
                    toreturn = PrintedText;
                }
            }

            return toreturn;
        }

        internal void SaveChangedText(string text, int selectedIndex)
        {
            foreach (var WeekDayItem in SubjectOrganizerDbContext.WeekDays.Include(w => w.Subject).Where(w => w.WeekDayInput == SelectedWeekDay.WeekDayInput))
            {
                if (WeekDayItem.WeekDayInput == WeekDaysCollection.SingleOrDefault(w => w.WeekDayInput == _selectedWeekDay.WeekDayInput).WeekDayInput)
                    WeekDayItem.Subject.SubjectInfo = text;

                CloseOpenSaveCloseConnection();
                break;
            }
        }

        internal void AddNewDay(string text)
        {
            bool doesitmatch = false;
            foreach (var item in MainCollection)
            {
                if (item.WeekNumber == _selectedWeekNr.WeekNumber && item.WeekDay.WeekDayInput == text)
                {
                    doesitmatch = true;
                }
            }

            if (!doesitmatch)
            {
                WeekNr WeekNr = new WeekNr
                {
                    WeekNumber = SelectedWeekNr.WeekNumber,
                    WeekDay = new WeekDay
                    {
                        WeekDayInput = text,
                        Subject = new Subject
                        { SubjectInfo = "Write an Activity here" }
                    }
                };

                // Updates database
                SubjectOrganizerDbContext.WeekNumbers.Add(WeekNr);

                // Updates local collections
                AddItemToMainCollection(WeekNr);

                // IMPORTANT to be last
                CloseOpenSaveCloseConnection();
            }
        }

        internal void RemoveSelectedDay()
        {
            WeekNr TempweekNr = new WeekNr
            {
                WeekNumber = SelectedWeekNr.WeekNumber,
                WeekDay = new WeekDay
                {
                    WeekDayInput = SelectedWeekDay.WeekDayInput,
                    Subject = new Subject { SubjectInfo = SelectedWeekDay.Subject.SubjectInfo }
                }
            };

            var itemInDatabase = SubjectOrganizerDbContext.WeekNumbers.Include(w => w.WeekDay).Include(wd => wd.WeekDay.Subject).FirstOrDefault(
                i => i.WeekNumber == TempweekNr.WeekNumber
                && i.WeekDay.WeekDayInput == TempweekNr.WeekDay.WeekDayInput
                && i.WeekDay.Subject.SubjectInfo == TempweekNr.WeekDay.Subject.SubjectInfo);

            var itemInLocalList = MainCollection.FirstOrDefault(
                i => i.WeekNumber == TempweekNr.WeekNumber
                && i.WeekDay.WeekDayInput == TempweekNr.WeekDay.WeekDayInput
                && i.WeekDay.Subject.SubjectInfo == TempweekNr.WeekDay.Subject.SubjectInfo);

            if (itemInLocalList != null && itemInDatabase != null)
            {
                SubjectOrganizerDbContext.WeekNumbers.Remove(itemInDatabase);
                CloseOpenSaveCloseConnection();
                MainCollection.Remove(itemInLocalList);

                UpdateWeekDaysCollection(MainCollection);
            }
            else
                throw new Exception("Was not able to find the object in the list or database");
        }

        private void AddItemToMainCollection(WeekNr weekNr)
        {
            MainCollection.Add(weekNr);
            UpdateWeekDaysCollection(MainCollection);
        }

        private void UpdateWeekDaysCollection(ObservableCollection<WeekNr> mainCollection)
        {
            WeekDaysCollection.Clear();
            CopyWeeksFromMainListAndRemoveDuplicates(mainCollection);
        }

        private void CloseOpenSaveCloseConnection()
        {
            SubjectOrganizerDbContext.Database.Connection.Close();
            SubjectOrganizerDbContext.Database.Connection.Open();
            SubjectOrganizerDbContext.SaveChanges();
            SubjectOrganizerDbContext.Database.Connection.Close();
        }


        public MainViewModel(ILabb1DataService labb1DataService)
        {
            MainCollection = new ObservableCollection<WeekNr>();
            SubjectsCollection = new ObservableCollection<Subject>();
            WeekDaysCollection = new ObservableCollection<WeekDay>();
            WeekListCollection = new ObservableCollection<WeekNr>();

            SubjectOrganizerDbContext = new SubjectOrganizerDbContext();

            _labb1DataService = labb1DataService;
        }

        public void Load()
        {
            if (MainCollection.Count == 0)
            {
                weeknrs = _labb1DataService.GetAll();

                MainCollection.Clear();
                //SubjectsCollection.Clear();
                WeekDaysCollection.Clear();

                foreach (var weekcontent in weeknrs)
                {
                    MainCollection.Add(weekcontent);
                    //SubjectsCollection.Add(weekcontent.WeekDay.Subject);
                }
            }

            CopyWeeksFromMainListAndRemoveDuplicates(MainCollection);
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

            DaysToDisplay();
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
