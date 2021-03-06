using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class Solver
    {
        int _populatinCount;
        private TimetableSettings _settings;
        private List<List<Lesson>> _lessons;
        private List<List<Lesson>> _groupsOnPractice;
        private ILogger _logger;
        public static List<Func<Timetable, int>> FitnessFunctions { get; set; }

        public Solver(List<List<Lesson>> lessons)
        {
            _groupsOnPractice = lessons.Where(x => x.Count == 0).ToList();
            lessons.RemoveAll(x => x.Count == 0);
            _lessons = lessons;
        }

        public Solver AddSettings(TimetableSettings settings)
        {
            _settings = settings;
            return this;
        }

        public Solver AddLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        private int Fitness(Timetable plan)
        {
            var res = 0;
            foreach (var f in FitnessFunctions)
                res += f(plan);
            return res;
        }

        private Population CreatePopulationBeforeTrain(Timetable timetable)
        {
            _settings = _settings is null ? TimetableDefaultSettings.Settings : _settings;
            _populatinCount = _settings.PopulationCount;
            var population = new Population(timetable.TryChange().TryAddLessons(), _settings);
            for (int i = 0; i < _populatinCount - 1; i++)
                population.AddChildOfParent(timetable);
            return population;
        }

        public async Task<Timetable> Train(Timetable timetable, CancellationTokenSource cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await Solve(CreatePopulationBeforeTrain(timetable), cancellationToken);
        }

        public async Task<Timetable> Solve(CancellationTokenSource cancellationToken)
        {
            _settings = _settings is null ? TimetableDefaultSettings.Settings : _settings;
            if (cancellationToken.IsCancellationRequested) return null;
            _populatinCount = _settings.PopulationCount;
            var pop = new Population(_lessons, _populatinCount, _settings);
            if (pop.Count == 0) throw new Exception("Can not create any plan");

            return await Solve(pop, cancellationToken);
        }

        private int _prevFitness = 0;
        private async Task<Timetable> Solve(Population pop, CancellationTokenSource cancellationToken)
        {
            try
            {
                return await Task.Run(() =>
                {
                    int count = _settings.MaxIterations;
                    int _partOfBest = _settings.PartOfBest;
                    while (count-- > 0)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            throw new OperationCanceledException("Timetable creation canceled");

                        pop.ForEach(p => p.FitnessValue = Fitness(p));

                        pop.Sort((p1, p2) => p1.FitnessValue.CompareTo(p2.FitnessValue));
                        if (pop[0].FitnessValue == 0) return pop[0];

                        if (_prevFitness != pop[0].FitnessValue)
                            _logger?.Log($"Текущая оценка: {_prevFitness = pop[0].FitnessValue}");

                        for (int i = pop.Count / _partOfBest; i < pop.Count; i++)
                            for (int j = 0; j < pop[i].PlanList.Length; j++)
                            {
                                for (int d = 0; d < _settings.DaysWeek; d++)
                                    for (int h = 0; h < _settings.HoursDay; h++)
                                        pop[i].PlanList[j][d, h].RemoveLesson();
                            }

                        for (int i = pop.Count / _partOfBest, j = 0; i < pop.Count; j++)
                            for (int k = 0; k < _partOfBest - 1; k++, i++)
                                pop.AddChildOfParentMem(j, i);
                    }

                    pop.ForEach(p => p.FitnessValue = Fitness(p));
                    pop.Sort((p1, p2) => p1.FitnessValue.CompareTo(p2.FitnessValue));
                    _logger?.Log($"Current fitness value: {_prevFitness = pop[0].FitnessValue}");
                    return pop[0];
                });
            }
            catch (OperationCanceledException e)
            {
                pop.ForEach(p => p.FitnessValue = Fitness(p));
                pop.Sort((p1, p2) => p1.FitnessValue.CompareTo(p2.FitnessValue));
                pop[0].Exception = e;
                return pop[0];
            }
        }
    }
}
