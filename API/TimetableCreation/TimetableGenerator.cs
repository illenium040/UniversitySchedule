using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TimetableAlgorithm;
using API.LessonsCreator;
using API.TimetableCreation.TimetableNormalization;

namespace API.TimetableCreation
{
    public class TimetableGenerator
    {
        private CancellationTokenSource _cancellation;
        private Solver _solver;

        protected ILessonsCreator LessonsCreator;
        protected INormalization Normalization;
        public TimetableDataContainer DataContainer { get; }

        public TimetableGenerator(
            ILessonsCreator lessonsCreator,
            TimetableDataContainer dataContainer,
            INormalization normalization)
        {
            LessonsCreator = lessonsCreator;
            DataContainer = dataContainer;
            Normalization = normalization;
            _cancellation = new CancellationTokenSource();
            Solver.FitnessFunctions = new List<Func<Timetable, int>>
            {
                FitnessFuncs.Windows,
                FitnessFuncs.EmptyDays
            };
            _solver = new Solver(LessonsCreator.Create(dataContainer));
        }

        public TimetableGenerator AddSettings(TimetableSettings settings)
        {
            _solver.AddSettings(settings);
            return this;
        }
        public TimetableGenerator AddLogger(ILogger logger)
        {
            _solver.AddLogger(logger);
            return this;
        }

        public async Task<TimetableHandler> Create()
        {
            try
            {
                if (_cancellation.IsCancellationRequested) UpdateCancellationToken();
                return new TimetableHandler(await _solver.Solve(_cancellation), Normalization, DataContainer);
            }
            catch (OperationCanceledException opCanceled)
            {
                throw opCanceled;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                UpdateCancellationToken();
            }
            
        }

        public async Task<TimetableHandler> Train(Timetable timetable)
        {
            try
            {
                if (_cancellation.IsCancellationRequested) UpdateCancellationToken();
                return new TimetableHandler(await _solver.Train(timetable, _cancellation), Normalization, DataContainer);
            }
            catch(OperationCanceledException opCanceled)
            {
                throw opCanceled;
            }
            catch (Exception exception)
            {
                throw exception;
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
