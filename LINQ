using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public static class LINQ 
    {
        public static IEnumerable<Book> FilterByYearBook(ref List<Book>List, int year)
        {
            try
            {
                return List.Where(x => x.YearPublished > year);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
        public static IEnumerable<Movie> SortByDurationMin(ref List<Movie>List)
        {
            try
            {
                return List.OfType<Movie>().OrderBy(x => x.DurationMin);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

    }
}
