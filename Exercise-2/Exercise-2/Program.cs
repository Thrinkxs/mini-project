using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace CSVProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = "Data.csv";
            var records = ReadCSVFile(csvFilePath);
            var firstNameFrequency = GetFrequency(records, r => r.FirstName!);
            var lastNameFrequency = GetFrequency(records, r => r.LastName!);
            // Merge the two dictionaries into one
            var nameFrequency = firstNameFrequency.Concat(lastNameFrequency)
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(g => g.Key, g => g.Sum(kvp => kvp.Value));

            // Order the merged dictionary by frequency and then by name
            var orderedNameFrequency = nameFrequency
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .ToList();
            WriteFrequencyToFile("name_frequency.txt", orderedNameFrequency);

     // Sort the addresses by ignoring the numbers at the beginning
        var addresses = records.Where(r => r.Address != null)
                           .Select(r => r.Address)
                           .OrderBy(a => System.Text.RegularExpressions.Regex.Replace(a!, @"^\d+\s", ""));

            WriteToFile("sorted_addresses.txt", addresses!);

            Console.WriteLine("Output files created successfully.");
        }

        static List<Person> ReadCSVFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(new CsvParser(reader, new CsvConfiguration(new System.Globalization.CultureInfo("en-US")))))
            {
                return csv.GetRecords<Person>().ToList();
            }
        }

        static Dictionary<string, int> GetFrequency(IEnumerable<Person> records, Func<Person, string> selector)
        {
            return records.GroupBy(selector)
                          .OrderByDescending(g => g.Count())
                          .ThenBy(g => g.Key)
                          .ToDictionary(g => g.Key, g => g.Count());
        }

        static void WriteFrequencyToFile(string filePath, IEnumerable<KeyValuePair<string, int>> data)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var kvp in data)
            {
                writer.WriteLine($"{kvp.Key},{kvp.Value}");
            }
        }

        static void WriteToFile(string filePath, IEnumerable<string> data)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var item in data)
            {
                writer.WriteLine(item);
            }
        }

        internal object GetFrequency(List<Person> people, Func<Person, string> value)
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}