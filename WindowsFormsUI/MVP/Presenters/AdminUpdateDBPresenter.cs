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
            View.LoadData += LoadData;

            _tableNames = new List<string>
            {
                "Преподаватель-предмет",
                "Специальность",
                "Группа",
                "Учебный план",
                "Информация о плане"
            };

            View.SetUpdateEvents();
        }

        private void LoadData()
        {
            try
            {
                View.IsPreLoading = true;
                _data = _loader.Load();
                View.SetData(_data);
                View.TableNameList = _tableNames;
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
                View.IsPreLoading = true;
                _data.Complete();
                View.IsSavedSuccesfully = true;
                MessageBox.Show("Данные сохранены", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                View.IsSavedSuccesfully = false;
                if (e.InnerException != null)
                    MessageBox.Show(e.InnerException.Message);
                else
                    MessageBox.Show(e.Message);
            }
            finally
            {
                View.IsPreLoading = false;
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
        }

        
    }
}
