using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions;
using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.LessonsCreator;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public class TimetableGenerator
    {
        private CancellationTokenSource _cancellation;
        private Solver _solver;

        protected ILessonsCreator LessonsCreator;
        protected TimetableDataContainer DataContainer;

        public TimetableGenerator(ILessonsCreator lessonsCreator, TimetableDataContainer dataContainer)
        {
            LessonsCreator = lessonsCreator;
            DataContainer = dataContainer;
            _cancellation = new CancellationTokenSource();
            Solver.FitnessFunctions = new List<Func<Timetable, int>>
            {
                FitnessFuncs.Windows,
                FitnessFuncs.EmptyDays
            };
            _solver = new Solver(LessonsCreator
                .AddTimetableData(DataContainer)
                .AppendGroups()
                .Create());
        }

        public TimetableGenerator AddSeetings(TimetableSettings settings)
        {
            _solver.AddSettings(settings);
            return this;
        }
        public TimetableGenerator AddLogger(ILogger logger)
        {
            _solver.AddLogger(logger);
            return this;
        }

        public async Task<TimetableResult> Create()
        {
            try
            {
                if (_cancellation.IsCancellationRequested) UpdateCancellationToken();
                return new TimetableAction(await _solver.Solve(_cancellation))
                    .Complete("Timetable created succesfully");
            }
            catch (OperationCanceledException opCanceled)
            {
                throw opCanceled;
            }
            catch (Exception exception)
            {
                return new TimetableAction()
                    .Fault($"Creation failed cause of the exception: {exception.Message}",exception);
            }
            finally
            {
                UpdateCancellationToken();
            }
            
        }

        public async Task<TimetableResult> Train(Timetable timetable)
        {
            try
            {
                if (_cancellation.IsCancellationRequested) UpdateCancellationToken();
                return new TimetableAction(await _solver.Train(timetable, _cancellation))
                    .Complete("Train ended succesfully");
            }
            catch(OperationCanceledException opCanceled)
            {
                throw opCanceled;
            }
            catch (Exception exception)
            {
                return new TimetableAction()
                    .Fault($"Creation failed cause of the exception: {exception.Message}", exception);
            }
            finally
            {
                UpdateCancellationToken();
            }
        }

        public void Cancel()
        {
            _cancellation.Cancel(true);
        }

        private void UpdateCancellationToken()
        {
            _cancellation = new CancellationTokenSource();
        }
    }
}
