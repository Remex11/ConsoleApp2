using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Library<T> : IMediaManager<T> where T : Media
    {
        private List<T> List = new List<T>();
        private Dictionary<string, T> Dictionary = new Dictionary<string, T>();


        public void Add(T item)
        {
            try
            {
                if (Dictionary.ContainsKey(item.Title))
                {
                    throw new InvalidOperationException("Элемент с таким названием уже существует");

                }
                List.Add(item);
                Dictionary.Add(item.Title, item);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        public bool Remove(string title)
        {
            try
            {
                if ((!Dictionary.ContainsKey(title)))
                {
                    throw new InvalidOperationException("Элемент с таким названием не существует");

                }
                var item = Dictionary[title];
                if (List.Remove(item) && Dictionary.Remove(title)) return true;
                return false;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        public IEnumerable<T> FilterByYear(int year)
        {
            return List.Where(x => x.YearPublished == year);
        }
        
        public void PrintAll()
        {
            foreach (var item in List)
            {
                Console.WriteLine(item.Title);
            }
        }

        public T FindByTitle(string title)
        {
            try
            {
                if (Dictionary.ContainsKey(title))
                {
                    return Dictionary[title];
                }
                throw new KeyNotFoundException($"Элемент с названием '{title}' не найден.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public IEnumerable<T> GetAllAvailable()
        {
           return List.Where(x => x.IsAvailable);
        }
        public void CheckOut(string title)
        {
            var item = FindByTitle(title);
            if (item != null)
            {
                if (item.IsAvailable)
                {
                    item.IsAvailable = false;
                    Console.WriteLine($"{item.Title} успешно выдан.");
                }
                else
                {
                    Console.WriteLine($"{item.Title} уже выдан и недоступен.");
                }
            }
        }
        public void Return(string title)
        {
            var item = FindByTitle(title);
            if (item != null)
            {
                if (!item.IsAvailable)
                {
                    item.IsAvailable = true;
                    Console.WriteLine($"{item.Title} успешно возвращен.");
                }
                else
                {
                    Console.WriteLine($"{item.Title} уже доступен в библиотеке.");
                }
            }
        }
        public IEnumerable<Book> FilterByYearBook(int year)
        {
            try
            {
                return List.OfType<Book>().Where(x => x.YearPublished > year).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
        public IEnumerable<Movie> SortByDurationMin()
        {
            try
            {
                return List.OfType<Movie>().OrderBy(x => x.DurationMin).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
        public IEnumerable<T> GetAvailable()
        {
            try
            {
                return List.Where(x => !x.IsAvailable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}
