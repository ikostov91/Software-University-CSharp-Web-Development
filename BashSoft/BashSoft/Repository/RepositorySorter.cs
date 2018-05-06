using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison == "ascending")
            {
                this.PrintStudents(studentsMarks.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
                //OrderAndTake(wantedData, studentsToTake, CompareInOrder);
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsMarks.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value)); ;
                //OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);    
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}
