using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminUpdateDBPresenter : BasePartialPresenter<IAdminFormUpdateDB, User>
    {
        private User _user;
        private ITimetableViewDataLoader _loader;
        private ITimetableViewData _data;
        private List<string> _tableNames;

        public AdminUpdateDBPresenter(IApplicationController controller, 
            ITimetableViewDataLoader viewDataLoader,
            IAdminFormUpdateDB view) 
            : base(controller, view)
        {
            _loader = viewDataLoader;
            View.SaveChanges += SaveChanges;
            View.TableChanged += TableChanged;
            View.LoadData += LoadData;
            View.LessonAdded += LessonAdded;
            View.LessonRemoved += LessonRemoved;
            View.LessonUpdated += LessonUpdated;

            _tableNames = new List<string>
            {
                "Преподаватель-предмет",
                "Специальность-группа",
                "Учебный план"
            };

            View.SetUpdateEvents();
        }

        private void LessonAdded(TeacherSubject obj)
        {
            _data.TeacherSubject.Add(obj);
        }

        private void LessonUpdated(TeacherSubject obj)
        {
            _data.TeacherSubject.Update(obj);
        }

        private void LessonRemoved(TeacherSubject obj)
        {
            _data.TeacherSubject.Remove(obj);
        }

        private void TableChanged()
        {
            View.IsPreLoading = true;
            switch (View.SelectedIndex)
            {
                case 0: View.SetLessons(_data.TeacherSubject); break;
                case 1: View.SetPlan(_data.PlansInformation); break;
                case 2: View.SetSpecialty(_data.Specialties);break;
                default: break;
            }
            View.IsPreLoading = false;
        }

        private void LoadData()
        {
            try
            {
                View.IsPreLoading = true;
                _data = _loader.Load();
                View.TableNameList = _tableNames;
                View.SetLessons(_data.TeacherSubject);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                View.IsPreLoading = false;
            }
            
        }

        private void SaveChanges()
        {
            try
            {
                _data.Complete();
            }
            catch (Exception e)
            {
                if(e.InnerException != null)
                    MessageBox.Show(e.InnerException.Message);
                else
                    MessageBox.Show(e.Message);
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
        }

        
    }
}
