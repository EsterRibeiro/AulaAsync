using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class StudentGradeService
    {
        private static readonly List<StudentGrade> _studentsGrade = new List<StudentGrade>();

        public double AverageGrade_Sync()
        {  
            double result = 0;

            if(_studentsGrade.Count == 0)
            {
                return 0;
            }

            foreach (var student in _studentsGrade)
            {
                result += student.Grade;
            }

            return result / _studentsGrade.Count;


        }

        public async Task<double> AverageGradeAsync()
        {
            return await Task.Run(AverageGrade_Sync);
        }

        public void AddGradeSync()
        {
            foreach (var studentG in _studentsGrade)
                studentG.Grade += 1;
        }

        public async Task AddGradeAsync()
        {
            await Task.Run(AddGradeSync);
      
        }

        public async Task AddGradeParallel()
        {
            await Task.Run(() =>
            {
                Parallel.For(0, _studentsGrade.Count,
                (i) => _studentsGrade[i].Grade++);
            });
                
        }

    }

   
}

